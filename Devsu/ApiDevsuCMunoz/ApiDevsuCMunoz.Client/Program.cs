using ApiDevsuCMunoz.Data;
using ApiDevsuCMunoz.Domain;

ApiDevsuCMunozDbContext dbContext = new();

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

var movimientos = new List<Movimiento> { 
    new Movimiento{
        Tipo = "Debito",
        Valor = -575,
        Saldo = 2000,
        NumCuenta = 478758
    },
};
await dbContext.AddRangeAsync(movimientos);
await dbContext.SaveChangesAsync();