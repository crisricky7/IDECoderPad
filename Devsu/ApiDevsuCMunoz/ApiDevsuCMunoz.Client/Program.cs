using ApiDevsuCMunoz.Domain;
using ApiDevsuCMunoz.Infrestructure.Persistence;
using Microsoft.EntityFrameworkCore;

ApiDevsuCMunozDbContext dbContext = new();
await QueryFilter();
//QueryCliente();

async Task QueryMethods() { 
    var clientes = await dbContext!.Clientes!.ToListAsync();

}

async Task QueryFilter() {
    var valorResult="Jose";
    var clientes = await dbContext!.Clientes!.Where(x => x.Id == 3).ToListAsync();

    foreach (var cliente in clientes) { 
        Console.WriteLine($"{cliente.Id}-{cliente.Nombre}-{cliente.Telefono}");
    }

    var clientesPart = await dbContext!.Clientes!.Where(x => EF.Functions.Like(x.Nombre, $"%{valorResult}%")).ToListAsync();
}

/*Cliente cliente = new() {
    Nombre = "Jose Lema",
    Genero = "Masculino",
    Edad = 5,
    Identificacion = "10123456",
    Direccion = "Otavalo sn y principal",
    Telefono = "098254785",
    Contrasenia = "1234",
    Estado = "True"
};

dbContext!.Clientes!.Add(cliente);

await dbContext.SaveChangesAsync();*/
/*
var cuentas = new List<Cuenta> {
    new Cuenta{
        Numero=478758,
        Tipo="Ahorro",
        SaldoInicial=2000,
        Estado="True",
        ClienteId=3
    }, 
};
await dbContext.AddRangeAsync(cuentas);
await dbContext.SaveChangesAsync();*/
/*
var movimientos = new List<Movimiento> { 
    new Movimiento{
        Tipo = "Debito",
        Valor = -575,
        Saldo = 2000,
        CuentaNumero = 478758
    },
};
await dbContext.AddRangeAsync(movimientos);
await dbContext.SaveChangesAsync();*/

void QueryCliente() { 
    var clientes = dbContext!.Clientes!.ToList();
    foreach (var cliente in clientes) { 
        Console.WriteLine($"{cliente.Id}-{cliente.Nombre}-{cliente.Telefono}");
    }
}