using System;
using System.Security;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a la Ruleta Americana");

        (string userName, int initialCredit) = GetUserData();
        int currentCredit = initialCredit;

        Console.WriteLine("¡Hola, " + userName + "! Es tu turno. Tu crédito inicial es: " + initialCredit);

        Console.Clear();

        while (true)
        {
            

            if (currentCredit == 0)
            {
                Console.WriteLine("¡Se acabaron tus créditos!");

                if (AskForMoreCredits())
                {
                    int additionalCredits = GetAdditionalCredits();
                    currentCredit += additionalCredits;
                    Console.WriteLine("¡Has recargado " + additionalCredits + " créditos! Tu nuevo saldo es: " + currentCredit);
                }
                else
                {
                    break; // Salir del juego si el usuario no desea agregar más créditos
                }
            }

            ShowRouletteBoard();

            Console.WriteLine("Ronda actual - Crédito disponible: " + currentCredit);

            int selectedBetType = GetBetType();

            switch (selectedBetType)
            {
                case 1: // Apuestas externas
                    int selectedExternalBet = GetExternalBetType();
                    switch (selectedExternalBet)
                    {
                        case 1: // Apuestas externas - Apuesta a columna
                            Console.WriteLine("Has seleccionado: Apuesta a columna");

                            int mount;
                            while (true)
                            {
                                Console.Write("Ingresa el monto que deseas apostar: ");
                                if (int.TryParse(Console.ReadLine(), out mount) && mount <= currentCredit)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("¡MOnto inválido! Ingresa un número válido.");
                                }
                            }

                            int selectedColumn = GetColumnChoice();

                            // Lógica para verificar si el número de la ruleta pertenece a la columna seleccionada
                            bool isWinColumn = IsColumnWin(selectedColumn);

                            if (isWinColumn)
                            {
                                Console.WriteLine("¡Has ganado!");
                                mount = mount * 2;
                                currentCredit = currentCredit + mount;
                                mount = 0;
                            }
                            else
                            {
                                Console.WriteLine("¡Has perdido!");
                                currentCredit = currentCredit - mount;
                                mount = 0;
                            }
                            break;
                        case 2: // Apuestas externas - Apuesta a color
                            Console.WriteLine("Has seleccionado: Apuesta a color");

                            int mount2;
                            while (true)
                            {
                                Console.Write("Ingresa el monto que deseas apostar: ");
                                if (int.TryParse(Console.ReadLine(), out mount2) && mount2 <= currentCredit)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("¡MOnto inválido! Ingresa un número válido.");
                                }
                            }

                            bool isRedBet = GetColorChoice();

                            // Lógica para verificar si el número de la ruleta corresponde al color seleccionado
                            bool isWinColor = IsColorWin(isRedBet);

                            if (isWinColor)
                            {
                                Console.WriteLine("¡Has ganado!");
                                currentCredit = currentCredit + mount2;
                                mount2 = 0;
                            }
                            else
                            {
                                Console.WriteLine("¡Has perdido!");
                                currentCredit = currentCredit - mount2;
                                mount2 = 0;
                            }
                            break;
                        case 3: // Apuestas externas - Apuesta par o impar
                            Console.WriteLine("Has seleccionado: Apuesta par o impar");

                            int mount3;
                            while (true)
                            {
                                Console.Write("Ingresa el monto que deseas apostar: ");
                                if (int.TryParse(Console.ReadLine(), out mount3) && mount3 <= currentCredit)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("¡MOnto inválido! Ingresa un número válido.");
                                }
                            }
                            bool isOddBet = GetOddChoice();

                            // Lógica para verificar si el número de la ruleta es par o impar según la elección
                            bool isOddWin = IsOddEvenWin(isOddBet);

                            if (isOddWin)
                            {
                                Console.WriteLine("¡Has ganado!");
                                currentCredit = currentCredit + mount3;
                                mount3 = 0;
                            }
                            else
                            {
                                Console.WriteLine("¡Has perdido!");
                                currentCredit = currentCredit - mount3;
                                mount3 = 0;
                            }
                            break;
                        case 4: // Apuestas externas - Apuesta por números bajos o altos
                            Console.WriteLine("Has seleccionado: Apuesta por números bajos o altos");

                            int mount4;
                            while (true)
                            {
                                Console.Write("Ingresa el monto que deseas apostar: ");
                                if (int.TryParse(Console.ReadLine(), out mount4) && mount4 <= currentCredit)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("¡MOnto inválido! Ingresa un número válido.");
                                }
                            }

                            bool isLowBet = GetLowHighChoice();

                            // Lógica para verificar si el número de la ruleta está dentro del rango seleccionado
                            bool isWin = IsLowHighWin(isLowBet);

                            if (isWin)
                            {
                                Console.WriteLine("¡Has ganado!");
                                currentCredit = currentCredit + mount4;
                                mount4 = 0;
                            }
                            else
                            {
                                Console.WriteLine("¡Has perdido!");
                                currentCredit = currentCredit + mount4;
                                mount4 = 0;
                            }
                            break;
                        default:
                            Console.WriteLine("Selección no válida. Inténtalo de nuevo.");
                            break;
                    }
                    break;
                case 2: // Apuestas internas
                    int selectedInternalBet = GetInternalBetType();
                    switch (selectedInternalBet)
                    {
                        case 1: // Apuestas internas - Apuesta directa
                            Console.WriteLine("Has seleccionado: Apuesta directa");
                            int mount5;
                            while (true)
                            {
                                Console.Write("Ingresa el monto que deseas apostar: ");
                                if (int.TryParse(Console.ReadLine(), out mount5) && mount5 <= currentCredit)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("¡MOnto inválido! Ingresa un número válido.");
                                }
                            }

                            int selectedNumber = GetDirectNumberChoice();

                            // Lógica para verificar si el número de la ruleta coincide con la elección del usuario
                            bool isWinDirect = IsDirectNumberWin(selectedNumber);

                            if (isWinDirect)
                            {
                                Console.WriteLine("¡Has ganado!");
                                currentCredit = currentCredit + (mount5 * 35);
                            }
                            else
                            {
                                Console.WriteLine("¡Has perdido!");
                                currentCredit = currentCredit - mount5;
                            }
                            break;
                        case 2: // Apuestas internas - Apuesta dividida
                            Console.WriteLine("Has seleccionado: Apuesta dividida");
                            int mount6;
                            while (true)
                            {
                                Console.Write("Ingresa el monto que deseas apostar: ");
                                if (int.TryParse(Console.ReadLine(), out mount6) && mount6 <= currentCredit)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("¡MOnto inválido! Ingresa un número válido.");
                                }
                            }
                            (int firstNumber, int secondNumber) = GetSplitNumbers();

                            // Lógica para verificar si el número de la ruleta coincide con la elección del usuario
                            bool isWinSplit = IsSplitNumbersWin(firstNumber, secondNumber);

                            if (isWinSplit)
                            {
                                Console.WriteLine("¡Has ganado!");
                                currentCredit = currentCredit + (mount6 * 17);
                            }
                            else
                            {
                                Console.WriteLine("¡Has perdido!");
                                currentCredit = currentCredit - mount6;
                            }
                            break;
                        case 3: // Apuestas internas - Apuesta a calle
                            Console.WriteLine("Has seleccionado: Apuesta a calle");
                            int mount7;
                            while (true)
                            {
                                Console.Write("Ingresa el monto que deseas apostar: ");
                                if (int.TryParse(Console.ReadLine(), out mount7) && mount7 <= currentCredit)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("¡MOnto inválido! Ingresa un número válido.");
                                }
                            }

                            int selectedStreet = GetStreetChoice();

                            // Lógica para verificar si el número de la ruleta coincide con la elección del usuario
                            bool isWinCalle = IsStreetWin(selectedStreet);

                            if (isWinCalle)
                            {
                                Console.WriteLine("¡Has ganado!");
                                currentCredit = currentCredit + (mount7 * 11);
                            }
                            else
                            {
                                Console.WriteLine("¡Has perdido!");
                                currentCredit = currentCredit - mount7;
                            }
                            break;
                        case 4: // Apuestas internas - Apuesta a esquina
                            Console.WriteLine("Has seleccionado: Apuesta a esquina");

                            int mount8;
                            while (true)
                            {
                                Console.Write("Ingresa el monto que deseas apostar: ");
                                if (int.TryParse(Console.ReadLine(), out mount8) && mount8 <= currentCredit)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("¡MOnto inválido! Ingresa un número válido.");
                                }
                            }


                            int selectedCorner = GetCornerChoice();

                            // Lógica para verificar si el número de la ruleta coincide con la esquina seleccionada
                            bool isWinCorner = IsCornerWin(selectedCorner);

                            if (isWinCorner)
                            {
                                Console.WriteLine("¡Has ganado!");
                                currentCredit = currentCredit + (mount8 * 11);
                            }
                            else
                            {
                                Console.WriteLine("¡Has perdido!");
                                currentCredit = currentCredit - mount8;
                            }
                            break;
                        case 5: // Apuestas internas - Apuesta a una línea
                            Console.WriteLine("Has seleccionado: Apuesta a una línea");

                            int mount9;
                            while (true)
                            {
                                Console.Write("Ingresa el monto que deseas apostar: ");
                                if (int.TryParse(Console.ReadLine(), out mount9) && mount9 <= currentCredit)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("¡MOnto inválido! Ingresa un número válido.");
                                }
                            }

                            int selectedLine = GetLineChoice();

                            // Lógica para verificar si el número de la ruleta coincide con la línea seleccionada
                            bool isWinLine = IsLineWin(selectedLine);

                            if (isWinLine)
                            {
                                Console.WriteLine("¡Has ganado!");
                                currentCredit = currentCredit + (mount9 * 5);
                            }
                            else
                            {
                                Console.WriteLine("¡Has perdido!");
                                currentCredit = currentCredit - mount9;
                            }
                            break;
                        default:
                            Console.WriteLine("Selección no válida. Inténtalo de nuevo.");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Selección no válida. Inténtalo de nuevo.");
                    break;
            }

            Console.WriteLine("Presiona Enter para continuar...");
            Console.ReadLine();

            Console.WriteLine("¿Deseas continuar jugando? (Sí/No):");
            string continuePlaying = Console.ReadLine().Trim().ToLower();

            if (continuePlaying != "sí" && continuePlaying != "si")
            {
                break; // Salir del juego si el usuario no desea continuar
            }

            Console.Clear();
        }

        Console.WriteLine("Gracias por jugar.");

        
    }



    static (string, int) GetUserData()
    {
        Console.Write("Por favor, ingresa tu nombre: ");
        string userName = Console.ReadLine();

        int initialCredit;
        while (true)
        {
            Console.Write("Ingresa tu crédito inicial: ");
            if (int.TryParse(Console.ReadLine(), out initialCredit))
            {
                break;
            }
            else
            {
                Console.WriteLine("¡Crédito inicial inválido! Ingresa un número válido.");
            }
        }

        return (userName, initialCredit);
    }

    static bool AskForMoreCredits()
    {
        Console.Write("¿Deseas ingresar más créditos? (Sí/No): ");
        string response = Console.ReadLine().Trim().ToLower();
        return response == "sí" || response == "si";
    }

    static int GetAdditionalCredits()
    {
        int additionalCredits;
        while (true)
        {
            Console.Write("Ingresa la cantidad de créditos adicionales que deseas agregar: ");
            if (int.TryParse(Console.ReadLine(), out additionalCredits))
            {
                break;
            }
            else
            {
                Console.WriteLine("¡Cantidad de créditos inválida! Ingresa un número válido.");
            }
        }
        return additionalCredits;
    }

    static int GetBetType()
    {
        int selectedBet;
        while (true)
        {
            Console.WriteLine("Selecciona el tipo de apuesta:");
            Console.WriteLine("1. Apuesta externa");
            Console.WriteLine("2. Apuesta interna");

            if (int.TryParse(Console.ReadLine(), out selectedBet) && (selectedBet == 1 || selectedBet == 2))
            {
                break;
            }
            else
            {
                Console.WriteLine("¡Selección inválida! Ingresa 1 para apuesta externa o 2 para apuesta interna.");
            }
        }
        return selectedBet;
    }

    static int GetExternalBetType()
    {
        int selectedBet;
        while (true)
        {
            Console.WriteLine("Selecciona el tipo de apuesta externa:");
            Console.WriteLine("1. Apuesta a columna");
            Console.WriteLine("2. Apuesta a color");
            Console.WriteLine("3. Apuesta par o impar");
            Console.WriteLine("4. Apuesta por números bajos o altos");

            if (int.TryParse(Console.ReadLine(), out selectedBet) && (selectedBet >= 1 && selectedBet <= 4))
            {
                break;
            }
            else
            {
                Console.WriteLine("¡Selección inválida! Ingresa un número válido del 1 al 4.");
            }
        }
        return selectedBet;
    }

    static int GetInternalBetType()
    {
        int selectedBet;
        while (true)
        {
            Console.WriteLine("Selecciona el tipo de apuesta interna:");
            Console.WriteLine("1. Apuesta directa");
            Console.WriteLine("2. Apuesta dividida");
            Console.WriteLine("3. Apuesta a calle");
            Console.WriteLine("4. Apuesta a esquina");
            Console.WriteLine("5. Apuesta a una línea");

            if (int.TryParse(Console.ReadLine(), out selectedBet) && (selectedBet >= 1 && selectedBet <= 5))
            {
                break;
            }
            else
            {
                Console.WriteLine("¡Selección inválida! Ingresa un número válido del 1 al 5.");
            }
        }
        return selectedBet;
    }


    static void ShowRouletteBoard()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Tablero de la Ruleta");
        Console.WriteLine(" ---------------");

        for (int i = 1; i <= 36; i++)
        {
            Console.BackgroundColor = (i % 2 == 0) ? ConsoleColor.Black : ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            if (i % 3 == 0)
            {
                Console.Write("| " + i.ToString().PadLeft(2) + " |");
                Console.WriteLine();
                Console.WriteLine(" ---------------");
            }
            else
            {
                Console.Write("| " + i.ToString().PadLeft(2) + " ");
            }
        }

        Console.ResetColor();
    }

    static int GetColumnChoice()
    {
        int selectedColumn;
        while (true)
        {
            Console.WriteLine("Selecciona la columna (1, 2 o 3):");
            if (int.TryParse(Console.ReadLine(), out selectedColumn) && (selectedColumn >= 1 && selectedColumn <= 3))
            {
                break;
            }
            else
            {
                Console.WriteLine("Selección no válida. Ingresa un número válido del 1 al 3.");
            }
        }
        return selectedColumn;
    }

    static bool IsColumnWin(int selectedColumn)
    {
        // Números en cada columna
        int[] column1 = { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 };
        int[] column2 = { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };
        int[] column3 = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 };

        // Simula el giro de la ruleta y el número resultante
        Random random = new Random();
        int resultNumber = random.Next(1, 37); // Genera un número aleatorio entre 1 y 36

        Console.WriteLine("Número resultante en la ruleta: " + resultNumber);

        // Verifica si el número resultante pertenece a la columna seleccionada
        switch (selectedColumn)
        {
            case 1:
                return Array.Exists(column1, num => num == resultNumber);
            case 2:
                return Array.Exists(column2, num => num == resultNumber);
            case 3:
                return Array.Exists(column3, num => num == resultNumber);
            default:
                return false;
        }
    }

    static bool GetColorChoice()
    {
        int colorChoice;
        while (true)
        {
            Console.WriteLine("Selecciona el color:");
            Console.WriteLine("1. Rojo (Impares)");
            Console.WriteLine("2. Negro (Pares)");
            if (int.TryParse(Console.ReadLine(), out colorChoice) && (colorChoice == 1 || colorChoice == 2))
            {
                break;
            }
            else
            {
                Console.WriteLine("Selección no válida. Ingresa 1 para rojo (impares) o 2 para negro (pares).");
            }
        }
        return colorChoice == 1; // Devuelve true para rojo (impares) y false para negro (pares)
    }

    static bool IsColorWin(bool isRedBet)
    {
        // Simula el giro de la ruleta y el número resultante
        Random random = new Random();
        int resultNumber = random.Next(1, 37); // Genera un número aleatorio entre 1 y 36

        Console.WriteLine("Número resultante en la ruleta: " + resultNumber);

        // Verifica si el número resultante corresponde al color seleccionado
        if (isRedBet)
        {
            // Rojo (impares): 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35
            return resultNumber % 2 != 0; // Impar
        }
        else
        {
            // Negro (pares): 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36
            return resultNumber % 2 == 0; // Par
        }
    }


    static bool GetOddChoice()
    {
        int oddChoice;
        while (true)
        {
            Console.WriteLine("Selecciona par o impar:");
            Console.WriteLine("1. Par");
            Console.WriteLine("2. Impar");
            if (int.TryParse(Console.ReadLine(), out oddChoice) && (oddChoice == 1 || oddChoice == 2))
            {
                break;
            }
            else
            {
                Console.WriteLine("Selección no válida. Ingresa 1 para par o 2 para impar.");
            }
        }
        return oddChoice == 2; // Devuelve true para impar y false para par
    }

    static bool IsOddEvenWin(bool isOddBet)
    {
        // Simula el giro de la ruleta y el número resultante
        Random random = new Random();
        int resultNumber = random.Next(1, 37); // Genera un número aleatorio entre 1 y 36

        Console.WriteLine("Número resultante en la ruleta: " + resultNumber);

        // Verifica si el número resultante es par o impar según la elección
        if (isOddBet)
        {
            return resultNumber % 2 != 0; // Impar
        }
        else
        {
            return resultNumber % 2 == 0; // Par
        }
    }

    static bool GetLowHighChoice()
    {
        int lowHighChoice;
        while (true)
        {
            Console.WriteLine("Selecciona números bajos o altos:");
            Console.WriteLine("1. Números bajos (1-18)");
            Console.WriteLine("2. Números altos (19-36)");
            if (int.TryParse(Console.ReadLine(), out lowHighChoice) && (lowHighChoice == 1 || lowHighChoice == 2))
            {
                break;
            }
            else
            {
                Console.WriteLine("Selección no válida. Ingresa 1 para números bajos o 2 para números altos.");
            }
        }
        return lowHighChoice == 1; // Devuelve true para números bajos y false para números altos
    }

    static bool IsLowHighWin(bool isLowBet)
    {
        // Simula el giro de la ruleta y el número resultante
        Random random = new Random();
        int resultNumber = random.Next(1, 37); // Genera un número aleatorio entre 1 y 36

        Console.WriteLine("Número resultante en la ruleta: " + resultNumber);

        // Verifica si el número resultante está dentro del rango seleccionado
        if (isLowBet)
        {
            return resultNumber >= 1 && resultNumber <= 18; // Números bajos (1-18)
        }
        else
        {
            return resultNumber >= 19 && resultNumber <= 36; // Números altos (19-36)
        }
    }

    static int GetDirectNumberChoice()
    {
        int selectedNumber;
        while (true)
        {
            Console.WriteLine("Selecciona un número entre 1 y 36:");
            if (int.TryParse(Console.ReadLine(), out selectedNumber) && (selectedNumber >= 1 && selectedNumber <= 36))
            {
                break;
            }
            else
            {
                Console.WriteLine("Número no válido. Ingresa un número válido del 1 al 36.");
            }
        }
        return selectedNumber;
    }

    static bool IsDirectNumberWin(int selectedNumber)
    {
        // Simula el giro de la ruleta y el número resultante
        Random random = new Random();
        int resultNumber = random.Next(1, 37); // Genera un número aleatorio entre 1 y 36

        Console.WriteLine("Número resultante en la ruleta: " + resultNumber);

        // Verifica si el número resultante coincide con la elección del usuario
        return resultNumber == selectedNumber;
    }

    static (int, int) GetSplitNumbers()
    {
        int firstNumber, secondNumber;
        while (true)
        {
            Console.WriteLine("Selecciona dos números adyacentes:");
            Console.Write("Primer número: ");
            if (int.TryParse(Console.ReadLine(), out firstNumber) &&
                (firstNumber >= 1 && firstNumber <= 36) )
            {
                break;
            }
            else
            {
                Console.WriteLine("Número no válido. Inténtalo de nuevo.");
            }
        }

        // Verifica la restricción para el número 36
        if (firstNumber == 36)
        {
            secondNumber = firstNumber - 1;
        }
        else
        {
            while (true)
            {
                Console.Write("Segundo número (solo n+1): ");
                if (int.TryParse(Console.ReadLine(), out secondNumber) &&
                    (secondNumber >= 1 && secondNumber <= 36) &&
                    (secondNumber == firstNumber + 1))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Número no válido. Inténtalo de nuevo.");
                }
            }
        }

        return (firstNumber, secondNumber);
    }


    static bool IsSplitNumbersWin(int firstNumber, int secondNumber)
    {
        // Simula el giro de la ruleta y el número resultante
        Random random = new Random();
        int resultNumber = random.Next(1, 37); // Genera un número aleatorio entre 1 y 36

        Console.WriteLine("Número resultante en la ruleta: " + resultNumber);

        // Verifica si el número resultante coincide con alguno de los números elegidos
        return resultNumber == firstNumber || resultNumber == secondNumber;
    }

    static int GetStreetChoice()
    {
        int selectedStreet;
        while (true)
        {
            Console.WriteLine("Selecciona una calle (1, 2 o 3):");
            if (int.TryParse(Console.ReadLine(), out selectedStreet) && (selectedStreet >= 1 && selectedStreet <= 3))
            {
                break;
            }
            else
            {
                Console.WriteLine("Selección no válida. Ingresa una calle válida (1, 2 o 3).");
            }
        }
        return selectedStreet;
    }

    static bool IsStreetWin(int selectedStreet)
    {
        // Simula el giro de la ruleta y el número resultante
        Random random =  new Random();
        int resultNumber = random.Next(1, 37); // Genera un número aleatorio entre 1 y 36

        Console.WriteLine("Número resultante en la ruleta: " + resultNumber);

        // Verifica si el número resultante coincide con alguno de los números de la calle seleccionada
        switch (selectedStreet)
        {
            case 1:
                return resultNumber >= 1 && resultNumber <= 3;
            case 2:
                return resultNumber >= 4 && resultNumber <= 6;
            case 3:
                return resultNumber >= 7 && resultNumber <= 9;
            default:
                return false;
        }
    }

    static int GetCornerChoice()
    {
        int selectedCorner;
        while (true)
        {
            Console.WriteLine("Selecciona una esquina (1, 2, 3 o 4):");
            if (int.TryParse(Console.ReadLine(), out selectedCorner) && (selectedCorner >= 1 && selectedCorner <= 4))
            {
                break;
            }
            else
            {
                Console.WriteLine("Selección no válida. Ingresa una esquina válida (1, 2, 3 o 4).");
            }
        }
        return selectedCorner;
    }

    static bool IsCornerWin(int selectedCorner)
    {
        // Simula el giro de la ruleta y el número resultante
        Random random = new Random();
        int resultNumber = random.Next(1, 37); // Genera un número aleatorio entre 1 y 36

        Console.WriteLine("Número resultante en la ruleta: " + resultNumber);

        // Verifica si el número resultante coincide con alguno de los números de la esquina seleccionada
        switch (selectedCorner)
        {
            case 1:
                return resultNumber == 1 || resultNumber == 2 || resultNumber == 4 || resultNumber == 5;
            case 2:
                return resultNumber == 2 || resultNumber == 3 || resultNumber == 5 || resultNumber == 6;
            case 3:
                return resultNumber == 31 || resultNumber == 32 || resultNumber == 34 || resultNumber == 35;
            case 4:
                return resultNumber == 32 || resultNumber == 33 || resultNumber == 35 || resultNumber == 36;
            default:
                return false;
        }
    }

    static int GetLineChoice()
    {
        int selectedLine;
        while (true)
        {
            Console.WriteLine("Selecciona una línea (1-11):");
            if (int.TryParse(Console.ReadLine(), out selectedLine) && (selectedLine >= 1 && selectedLine <= 11))
            {
                break;
            }
            else
            {
                Console.WriteLine("Selección no válida. Ingresa una línea válida (1-11).");
            }
        }
        return selectedLine;
    }

    static bool IsLineWin(int selectedLine)
    {
        // Simula el giro de la ruleta y el número resultante
        Random random = new Random();
        int resultNumber = random.Next(1, 37); // Genera un número aleatorio entre 1 y 36

        Console.WriteLine("Número resultante en la ruleta: " + resultNumber);

        // Define las líneas en el tablero de ruleta americana
        int[][] lines = new int[][]
        {
        new int[] { 1, 2, 3, 4, 5, 6 },
        new int[] { 7, 8, 9, 10, 11, 12 },
        new int[] { 13, 14, 15, 16, 17, 18 },
        new int[] { 19, 20, 21, 22, 23, 24 },
        new int[] { 25, 26, 27, 28, 29, 30 },
        new int[] { 31, 32, 33, 34, 35, 36 },
        new int[] { 1, 4, 7, 10, 13, 16 },
        new int[] { 2, 5, 8, 11, 14, 17 },
        new int[] { 3, 6, 9, 12, 15, 18 },
        new int[] { 19, 22, 25, 28, 31, 34 },
        new int[] { 20, 23, 26, 29, 32, 35 }
        };

        // Verifica si el número resultante coincide con alguno de los números en la línea seleccionada
        foreach (int number in lines[selectedLine - 1])
        {
            if (resultNumber == number)
            {
                return true;
            }
        }

        return false;
    }



}
