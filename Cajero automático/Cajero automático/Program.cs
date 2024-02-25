
//1.- Realiza un sistema que solicite un NIP de cajero al usuario que sea válido (NIP=3867)si el NIP es inválido el sistema deberá permitir 3 intentos más.
//2.-Inicia el saldo del usuario en $4.000,00 y muestra en pantalla el menú.
//3.-El menú deberá permitir: Consultar Saldo, Retirar de Efectivo, Consultar Movimientos y Salir.


bool access = false;
int attempts = 1;
int balance = 4000;
List<string> movimiento = new List<string>();

while (access == false && attempts <= 4)
{
    Console.WriteLine("Ingrese su código de acceso: ");
    int nip = Convert.ToInt32(Console.ReadLine());
    if (nip != 3867)
    {
        Console.Clear();
        Console.WriteLine("Código de ingreso invalido, vuelva a intentarlo. {0}/4", attempts);
        attempts++;
        
    }
    else if (attempts >= 5)
    {
        Console.Clear();
        Console.WriteLine("Intentos agotados, vuelva a ingresar en unos momentos!");
;
    }
    else
    {
        access = true;
    }
   
}


while(access == true)
{
    Console.Clear();

    Console.WriteLine("\n\n\n             Bienvenidos a nuestros sistema de cajeros automáticos!\n\n\n");

    Console.WriteLine("1- Consultar saldo \n\n2- Retirar efectivo \n\n2- Últimos movimientos \n\n0- Salir");
  
    switch (Convert.ToInt32(Console.ReadLine()))
    {
        case 1:
            Console.Clear();
            Console.WriteLine(balance);
            Console.WriteLine("Precione cualquier tecla para volver:");
            Console.ReadKey(true);

            break;
        case 2:
            Console.Clear();
            Console.WriteLine("Indique la cantidad a retirar: ");
            int monto = Convert.ToInt32(Console.ReadLine());
            if (monto > 0 && monto <= balance) { balance -= monto; Console.WriteLine("Retiro exitoso. Su nuevo saldo es: $" + balance);
            }
            else
            {
                Console.WriteLine("Monto inválido o insuficiente fondos.\n\n");
            }

            movimiento.Add($"Retiró en efectivo: ${monto}." + "\n"+ "Dia y hora: "+ DateTime.Now.ToString()+"\n");
            Console.WriteLine("Precione cualquier tecla para volver:");
            Console.ReadKey(true);
            break;

        case 3:
            Console.Clear();
            Console.WriteLine("--Ultimos movimientos--\n");
            foreach(string data in movimiento) { Console.WriteLine(data); }
            Console.ReadKey(true);
            break;

        case 0:
            access = false;
            Console.Clear();
            Console.WriteLine("Gracias por habe utilizado nuestros servicios");
            break;
        default: Console.Clear();  Console.WriteLine("Opcion incorrecta, vuelva a ingresar otra"); break;
    }

}