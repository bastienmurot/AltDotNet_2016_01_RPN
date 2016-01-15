using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RPN_Test
{
    public class RPN
    {
        public static int Compute(string input)
        {
            var stack = new Stack<int>();

            foreach (var data in input.Split(' '))
            {
                int value;
                if (int.TryParse(data, out value))
                {
                    stack.Push(value);
                }
                else
                {
                    var op1 = stack.Pop();
                    var op2 = stack.Pop();

                    switch (data)
                    {
                        case "+":
                            stack.Push(op2 + op1);
                            break;
                        case "-":
                            stack.Push(op2 - op1);
                            break;
                        case "*":
                            stack.Push(op2 * op1);
                            break;
                        case "/":
                            stack.Push(op2 / op1);
                            break;
                    }
                }
            }

            return stack.Peek();
        }
    }


    [TestClass]
    public class RPNTest
    {
        [TestMethod]
        public void Test_Only_One_Operand()
        {
            var result = RPN.Compute("5");

            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void Test_Two_Operand_Single_Add()
        {
            var result = RPN.Compute("5 4 +");

            Assert.AreEqual(result, 9);
        }

        [TestMethod]
        public void Test_Three_Operand_Double_Add()
        {
            var result = RPN.Compute("5 4 1 + +");

            Assert.AreEqual(result, 10);
        }

        [TestMethod]
        public void Test_Three_Operand_Double_Add_Other()
        {
            var result = RPN.Compute("5 4 + 1 +");

            Assert.AreEqual(result, 10);
        }

        [TestMethod]
        public void Test_Two_Operand_Single_Soustract()
        {
            var result = RPN.Compute("5 4 -");

            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void Test_Three_Operand_Double_Soustract()
        {
            var result = RPN.Compute("5 4 1 - -");

            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void Test_Three_Operand_Double_Soustract_Other()
        {
            var result = RPN.Compute("5 4 - 1 -");

            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void Test_Two_Operand_Single_Multiply()
        {
            var result = RPN.Compute("5 4 *");

            Assert.AreEqual(result, 20);
        }

        [TestMethod]
        public void Test_Two_Operand_Single_Divide()
        {
            var result = RPN.Compute("20 4 /");

            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void Test_Complex_Operation()
        {
            var result = RPN.Compute("5 1 2 + 4 * + 3 -");

            Assert.AreEqual(result, 14);
        }
    }
}