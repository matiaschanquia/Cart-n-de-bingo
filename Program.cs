
Console.WriteLine("Clase 9 - Ejercicio 2 - Cartón de bingo \n");

int[,] carton = new int[3, 9];

int lengthFilas = carton.GetUpperBound(0) + 1;
int lengthColumnas = carton.GetUpperBound(1) + 1;

int indiceVacio;
int contadorVacio = 3;
int contadorLleno = 3;
while (contadorVacio == 3 || contadorLleno == 3)
{
    carton = new int[3, 9];
    for (int i = 0; i < lengthFilas; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            indiceVacio = new Random().Next(0, 9);
            while (carton[i, indiceVacio] == -1)
            {
                indiceVacio = new Random().Next(0, 9);
            }
            carton[i, indiceVacio] = -1;
        }
    }
    for (int j = 0; j < lengthColumnas; j++)
    {
        contadorVacio = 0;
        contadorLleno = 0;
        for (int i = 0; i < lengthFilas; i++)
        {
            if (carton[i, j] == -1)
            {
                contadorVacio++;
            }
            else
            {
                contadorLleno++;
            }
        }
        if (contadorVacio == 3 || contadorLleno == 3)
        {
            break;
        }
    }
}

int[,] copiaCarton = carton;
int columna = 0;
int contadorIguales = 1;

while (contadorIguales == 1)
{
    carton = copiaCarton;
    for (int i = 0; i < 3; i++)
    {
        for (int lim = 10; lim <= 90; lim += 10)
        {   
            if (carton[i, columna] != -1)
            {
                if (lim == 10)
                {
                    carton[i, columna] = new Random().Next(lim-9, lim);
                }
                else if (lim == 90)
                {
                    carton[i, columna] = new Random().Next(lim-10, lim+1);
                }
                else
                {
                    carton[i, columna] = new Random().Next(lim-10, lim);
                }
            }
            columna++;
        }
        columna = 0;
    }

    for (int j = 0; j < lengthColumnas; j++)
    {
        contadorIguales = 0;
        if (carton[0, j] == carton[1, j] && carton[0, j] != -1)
        {
            contadorIguales++;
        }
        if (carton[1, j] == carton[2, j] && carton[1, j] != -1)
        {
            contadorIguales++;
        }
        if (carton[0, j] == carton[2, j] && carton[2, j] != -1)
        {
            contadorIguales++;
        }
        if (contadorIguales == 1)
        {
            break;
        }
    }
}


for (int i = 0; i < 3; i++)
{
    Console.WriteLine();
    for (int j = 0; j < 9; j++)
    {
        Console.Write("| ");
        if (carton[i, j] == -1)
        {
            Console.Write("♥♥");
        }
        else
        {
            if (j == 0)
            {
                Console.Write(" " + carton[i, j]);
            }
            else
            {
                Console.Write(carton[i, j]);
            }
        }
        Console.Write(" |");
    }
}
Console.WriteLine();