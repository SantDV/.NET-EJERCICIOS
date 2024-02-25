



Console.WriteLine("Ingrese la cantidad de alumnos a registrar");
int alumnosCount = Convert.ToInt32(Console.ReadLine());

Decimal[,] miArreglo = new Decimal[alumnosCount, 2];

Console.WriteLine();

for (int i = 0; i < alumnosCount; i++)
{
    Console.WriteLine("Calificaciones del alumno #" + (i+1));
    miArreglo[i, 0] = (i + 1);
    miArreglo[i, 1] = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine();
}


int calificacion = 0;
int alumno = 0;

for (int i = 0; i < alumnosCount; i++)
{
    if (miArreglo[i, 1] > calificacion)
    {
        calificacion = Convert.ToInt32(miArreglo[i, 1]);
        alumno = Convert.ToInt32(miArreglo[i, 0]);
    }
}

Console.WriteLine("El alumno con la mayor calificacion fue: {0}", alumno);

