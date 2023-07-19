using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Application.Exceptions;
using ApiDevsuCMunoz.Application.Models;
using ApiDevsuCMunoz.Domain;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiDevsuCMunoz.Application.Features.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, RespuestaTransaccionCliente>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateClienteCommandHandler> _logger;

        public UpdateClienteCommandHandler(IClienteRepository clienteRepository, IMapper mapper, ILogger<UpdateClienteCommandHandler> logger)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<RespuestaTransaccionCliente> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var clienteToUpdate = await _clienteRepository.GetByIdAsync(request.Id);
                if (clienteToUpdate == null)
                {
                    _logger.LogError($"No se encontro el cliente con id {request.Identificacion}");
                    throw new NotFoundException(nameof(Cliente), request.Identificacion);
                    return new RespuestaTransaccionCliente
                    {
                        Status = "NOOK",
                        Message = "El cliente no existe",
                        Cliente = null
                    };

                }
                else
                {
                    _mapper.Map(request, clienteToUpdate, typeof(UpdateClienteCommand), typeof(Cliente));

                    await _clienteRepository.UpdateAsync(clienteToUpdate);
                    _logger.LogInformation($"La operación fue exitosa actualizando el cliente {request.Identificacion}");
                    return new RespuestaTransaccionCliente
                    {
                        Status = "OK",
                        Message = null,
                        Cliente = null
                    };
                }
            }
            catch (Exception ex) {
                return new RespuestaTransaccionCliente
                {
                    Status = "NOOK",
                    Message = ex.Message,
                    Cliente = null
                };
            }
        }
    }
}