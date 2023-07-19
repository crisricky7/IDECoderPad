using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Application.Exceptions;
using ApiDevsuCMunoz.Application.Models;
using ApiDevsuCMunoz.Domain;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiDevsuCMunoz.Application.Features.Clientes.Commands.DeleteCliente
{
    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, RespuestaTransaccionCliente>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteClienteCommandHandler> _logger;

        public DeleteClienteCommandHandler(IClienteRepository clienteRepository, IMapper mapper, ILogger<DeleteClienteCommandHandler> logger)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<RespuestaTransaccionCliente> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var clienteToDelete = await _clienteRepository.GetByIdAsync(request.Id);
                if (clienteToDelete == null)
                {
                    _logger.LogError($"No se encontro el cliente con Id {request.Id}");
                    return new RespuestaTransaccionCliente
                    {
                        Status = "NOOK",
                        Message = "No se encontro el cliente con Id " + request.Id,
                        Cliente = null,
                    };
                }
                else
                {
                    var validaCliente = _clienteRepository.ValidarCliente(clienteToDelete);
                    if (validaCliente.Status.Equals("OK"))
                    {
                        await _clienteRepository.DeleteAsync(clienteToDelete);
                        _logger.LogInformation($"La operación fue exitosa eliminando el cliente {request.Id}");
                        return new RespuestaTransaccionCliente
                        {
                            Status = "OK",
                            Message = "La operación fue exitosa eliminando el cliente " + request.Id,
                            Cliente = null,
                        };
                    }
                    else {
                        return new RespuestaTransaccionCliente
                        {
                            Status = validaCliente.Status,
                            Message = validaCliente.Message,
                            Cliente = null,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new RespuestaTransaccionCliente
                {
                    Status = "NOOK",
                    Message = "Error al momento de eliminar el cliente contacto con el Administrador del Sistema",
                    Cliente = null,
                };
            }
        }
    }
}