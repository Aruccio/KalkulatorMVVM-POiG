using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CalculatorMVVM.VIewModel
{
    using Model;
    using Model.Operations;
    using BaseClass;

    //  Główna klasa warstwy ViewModel będąca abstrakcją widoku kalkulatora.
    //  Zawiera cztery wielkości opisujące widok kalkulatora:
    //    - FirstArgument - typu double?
    internal class Calculating: ViewModelBase
    {
        //tworzymy instancję modelu w obrębie obiektu będącego ViewModelem
        
        private Calculator calculator = new Model.Calculator();

        //konstruktor
        public Calculating()
        {
            //decydujemy, w jakie operacje wyposażamy nasz kalkulator + - * /
            // operacje definiowane są w warstwie modelu
            calculator.AddOperation(new Addtion());
            calculator.AddOperation(new Subtraction());
            calculator.AddOperation(new Multiplication());
            calculator.AddOperation(new Division());
        }


        #region Interfejs publiczny 
        //abstrakcja opisująca model widoku składa się z:
        //  FirstArg - lewy argument opreacji
        //  SecondArg - drugi argument operacji
        //  symboOfCurrentOperation - symbolu bieżącej operacji
        //  result - wynik
        // Wszystkie te pola i odpowiadjące im publiczne własności
        // są typu nullable (mogą przyjmować  wartość null)
        // gdzie null oznacza brak podanej wartości po stronie widoku

        private decimal? firstArg = null;
        public decimal? FirstArg {
            get { return firstArg; }
            set
            {
                firstArg = value;
                onPropertyChanged(nameof(FirstArg), nameof(Result));
            }
                
        }

        private decimal? secondArg = null;
        public decimal? SecondArg
        {
            get { return secondArg; }
            set
            {
                secondArg = value;
                onPropertyChanged(nameof(SecondArg), nameof(Result));
            }

        }

        private string symbolOfCurrentOperation = null;
        public string SymbolOfCurrentOperation {
            get { return symbolOfCurrentOperation; }
            set 
            {
                symbolOfCurrentOperation = value;
                onPropertyChanged(nameof(SymbolOfCurrentOperation), nameof(Result));
            } 
        }

        //własność Result sama oblicza wynik, gdy tylko jest to możliwe
        //widok przy każdym zgłoszeniu zmiany tej własności o nią odpyta
        //a get zwrócić co trzeba

        private decimal? result = null;
        public decimal? Result
        {
            get
            {
                if (InfoText!="Wynik:")
                {
                    InfoText = "Wynik:";
                    onPropertyChanged(nameof(InfoText));
                }

                //w przypadku gdy któryś z agumentów działania jest null zwracamy null
                if (firstArg == null || secondArg == null || string.IsNullOrEmpty(symbolOfCurrentOperation)) 
                        return null;
                //dzielenie przez zero
                if (symbolOfCurrentOperation == "/" && secondArg == 0)
                {
                    InfoText = "Nie dziel przez zero";
                    onPropertyChanged(nameof(InfoText));
                    return null;
                }
                //przy poprawnych argumentach wykonaj obliczenie
                return calculator.ExceuteOperationBySymbol(symbolOfCurrentOperation,(decimal)firstArg,(decimal)secondArg);
            }
            set
            {
                result = value;                
            }
        }


        // składowa interfejsu publicznego, która 
        // reprezentuje symbole dostępnych w kalkulatorze operacji 
        // czym załadowany zostaje w widoku comboBox z operacjami
        public string[] OperationsName
        {

            get
            {
                return calculator.SymbolsOfOoperations;
            }


        }

        public string InfoText { get; set; } = "Wynik:";
        #endregion
                     
       
     }
}
