using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication3;

namespace ConsoleApplication3

{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Add_OneIntegerAddedToEmptyList_SingleIntegerInResultingList()
        {
            //Arrange
            FakeList<int> fakelist = new FakeList<int>();
            int integerAdded = 1;


            //Act
            fakelist.Add(integerAdded);
            //Assert
            Assert.AreEqual(integerAdded, fakelist[0]);
        }

        [TestMethod]
        public void Add_OneLetterAddedToEmptyList_SingleLetterString()
        {
            //Arrange
            FakeList<string> fakelist = new FakeList<string>();
            string stringAdded = "a";
            string expectedResult = "a";

            //Act
            fakelist.Add(stringAdded);

            //Assert
            Assert.AreEqual(expectedResult, fakelist[0]);
        }



        [TestMethod]
        public void Add_ArrayOfIntegersAddedToEmptyList_AddedArray()
        {
            //Arrange
            FakeList<Array> fakelist = new FakeList<Array>();
            int[] expectedResult = new int[2] { 1, 2 };

            //Act
            fakelist.Add(expectedResult);

            //Assert
            Assert.AreEqual(expectedResult, fakelist[0]);
        }


        //Add Two Arrays
        [TestMethod]
        public void Add_TwoIntegerArraysAddedToEmptyList_ArraysNotCombined()
        {
            //Arrange
            FakeList<Array> fakelist = new FakeList<Array>();
            int[] firstArrayAdded = new int[2] { 1, 2 };
            int[] secondArrayAdded = new int[2] { 3, 4 };
            
            //Act
            fakelist.Add(firstArrayAdded);
            fakelist.Add(secondArrayAdded);
            //Assert
            Assert.AreEqual(secondArrayAdded, fakelist[1]);
        }

        //Following tests are on a list arranged to not be empty


        [TestMethod]
        public void Add_IntegerToExistingList_ExistingListThenIntegerNotSum()
        {
            //Arrange
            FakeList<int> fakelist = new FakeList<int>();
            int integerInZeroIndex = 1;
            int integerAdded = 2;
            
            //Act
            fakelist.Add(integerInZeroIndex);
            fakelist.Add(integerAdded);
            
            //Assert
            Assert.AreEqual(integerAdded, fakelist[1]);
        }

        [TestMethod]
        public void Add_StringToExistingList_ExistingPlusNewString()
        {
            //Arrange
            FakeList<string> fakelist = new FakeList<string>();
            fakelist.Add("a");
            string stringAdded = "b";
            string expectedValueInIndexOne = "b";

            //Act
            fakelist.Add(stringAdded);

            //Assert
            Assert.AreEqual(expectedValueInIndexOne, fakelist[1]);
        }

        [TestMethod]
        public void Add_TwoStringsAddedToListofOne_ThirdIndexHoldsSecondAddedString()
        {
            //Arrange
            FakeList<string> fakelist = new FakeList<string>();
            string valueInZeroIndex ="a";
            string valueAddedSecond = "b";
            string valueAddedThird = "c";

            //Act
            fakelist.Add(valueInZeroIndex);    
            fakelist.Add(valueAddedSecond);
            fakelist.Add(valueAddedThird);

            //Assert
            Assert.AreEqual(valueAddedThird, fakelist[2]);
        }

        [TestMethod]
        public void Add_ArrayToExistingListOfArrays_ArrayAddedInNewIndex()
        {
            //Arrange
            FakeList<Array> fakelist = new FakeList<Array>();
            int[] x = new int[2] { 1, 2 };
            int[] arrayAdded = new int[2] { 3, 4 };

            //Act
            fakelist.Add(x);
            fakelist.Add(arrayAdded);

            //Assert
            
            Assert.AreEqual(arrayAdded, fakelist[1]);
        }

        [TestMethod]
        public void Add_SimpleIntegerLists_InitialValueRemains()
        {
            //Arrange
            FakeList<int> fakelist = new FakeList<int>();
            int integerInZeroIndex = 1;
            int integerAdded = 2;

            //Act
            fakelist.Add(integerInZeroIndex);
            fakelist.Add(integerAdded);
            //Assert
            Assert.AreEqual(integerInZeroIndex, fakelist[0]);
        }

        [TestMethod]
        public void Add_IntAddedToEmptyList_CountIncreasesByOne()
        {
            //Arrange
            FakeList<int> fakelist = new FakeList<int>();
            int expectedCount = 1;


            //Act
            fakelist.Add(1);

            //Assert
            Assert.AreEqual(expectedCount, fakelist.Count);
        }

        [TestMethod]
        public void Remove_RepeatedIntegerRemovedFromIntList_NewListWithoutFirstInt()
        {
            //Arrange
            FakeList<int> fakelist = new FakeList<int>(){1, 2, 3, 3, 4 };
            int integerToRemove = 3;
            int expectedValueInIndexThree = 4;


            //Act
            fakelist.Remove(integerToRemove);

            //Assert
            Assert.AreEqual(expectedValueInIndexThree, fakelist[3]);
        }

        [TestMethod]
        public void Remove_RepeatedIntegersExist_OnlyOneRemoved()
        {
            //Arrange
            FakeList<int> fakelist = new FakeList<int>() { 1, 3, 3, 4, 4 };
            int integerToRemove = 4;
            int expectedValueInIndexThree = 4;


            //Act
            fakelist.Remove(integerToRemove);

            //Assert
            Assert.AreEqual(expectedValueInIndexThree, fakelist[3]);
        }

        [TestMethod]
        public void Remove_ListOfTwoArraysRemovingSecond_RemainingArrayInZeroIndex()
        {//to show {[1,2],[3,4]}   .Remove([1,2]) --> {[3,4]}

            //Arrange
            FakeList<int []> fakelist = new FakeList<int []>();
            int[] arrayInZeroIndex = new int[2];
            arrayInZeroIndex[0] = 1;
            arrayInZeroIndex[1] = 2;
            int[] arrayInOneIndex = new int[2];
            arrayInOneIndex[0] = 3;
            arrayInOneIndex[1] = 4;

            //Act
            fakelist.Add(arrayInZeroIndex);
            fakelist.Add(arrayInOneIndex);
            fakelist.Remove(arrayInZeroIndex);

            //Assert
            Assert.AreEqual(arrayInOneIndex, fakelist[0]);     
        }

        [TestMethod]
        public void Remove_OneOfTwoArraysRemoved_RemainingArrayIndexesCorrect()
        {
            //Arrange
            FakeList<int[]> fakelist = new FakeList<int[]>();
            int[] arrayInZeroIndex = new int[2];
            arrayInZeroIndex[0] = 1;
            arrayInZeroIndex[1] = 2;
            int[] arrayInOneIndex = new int[2];
            arrayInOneIndex[0] = 3;
            arrayInOneIndex[1] = 4;

            //Act
            fakelist.Add(arrayInZeroIndex);
            fakelist.Add(arrayInOneIndex);
            fakelist.Remove(arrayInZeroIndex);

            //Assert
            Assert.AreEqual(3, fakelist[0][0]);          
        }



        [TestMethod]
        public void Remove_IntegerRemovedFromList_SubsequentIndexesDecrementOne()
        {
            //Arrange
            FakeList<int> fakelist = new FakeList<int>() { 1, 2, 3, 4 };
            int integerToRemove = 2;
            int valueExpectedInThirdIndex = 4;

            //Act
            fakelist.Remove(integerToRemove);

            //Assert
            Assert.AreEqual(valueExpectedInThirdIndex, fakelist[2]);
        }

        [TestMethod]
        public void Remove_OneItemInListRemoved_CountDecreasesByOne()
        {
            //Arrange
            FakeList<int> fakelist = new FakeList<int>() { 1, 2, 3, 4 };
            int integerToRemove = 2;
            int expectedCountAfterRemoval = 3;
            //Act
            fakelist.Remove(integerToRemove);

            //Assert
            Assert.AreEqual(expectedCountAfterRemoval, fakelist.Count);
        }

        [TestMethod]
        public void Remove_ListContainsItemToRemove_TrueReturned()
        {
            //Arrange
            FakeList<int> fakelist = new FakeList<int>() {1};
            int integerRemoved = 1;
            bool expectedReturnBool;

            //Act
            expectedReturnBool = fakelist.Remove(integerRemoved);

            //Assert
            Assert.IsTrue(expectedReturnBool);
        }

        [TestMethod]
        public void Remove_ListWithoutItemToRemove_FalseReturned()
        {
            //Arrange
            FakeList<int> fakelist = new FakeList<int>() { 2 };
            int integerRemoved = 2;
            bool expectedReturnBool;

            //Act
            expectedReturnBool = fakelist.Remove(integerRemoved);

            //Assert
            Assert.IsTrue(expectedReturnBool);
        }

        [TestMethod]
        public void GetItem_ItemExistsInList_ItemInIndexReturned()
        {
            //Arrange
            FakeList<int> fakelist = new FakeList<int>() { 1, 2, 3, 4 };
            int itemExpectedInIndexOne = 2;

            //Act
            int returnedItem =fakelist.GetItem(1);

            //Assert
            Assert.AreEqual(itemExpectedInIndexOne, returnedItem);
        }


        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetItem_IndexRequestedOutOfRange_OutOfRangeException()
        {
            //Arrange
            FakeList<int> fakelist = new FakeList<int>() { 1, 2 };

            //Act
            fakelist.GetItem(3);
            //Assert is taken care of already. Test passes if exception is thrown
        }

        [TestMethod]
        public void IterateOverFakeList_ForLoopReproducesListItems_NewArrayHasSameThirdIndexValue()
        {
            //Arrange
            FakeList<int> fakelist = new FakeList<int>() { 1, 2, 3, 4 };
            int[] testHolderArray = new int[4];

            //Act
            int i = 0;
            foreach (var item in fakelist)
            {
                testHolderArray[i] = item;
                i++;
            }
            //Assert
            Assert.AreEqual(testHolderArray[2], fakelist[2]);
        }
        
        [TestMethod]
        public void ToString_ListOfStrings_OneStringWithCommas()
        {
            //Arrange               
            FakeList<string> fakelist = new FakeList<string>(){"a", "b", "dog" };
            string expectedResult =  "a, b, dog";

            //Act
            string resultingString = fakelist.ToString();

            //Assert
            Assert.AreEqual(expectedResult, resultingString);
        }

        [TestMethod]
        public void ToString_ListOfIntegers_OneStringWithCommas()
        {
            //Arrange
            FakeList<int> fakelist = new FakeList<int>() { 1,2,3,44};
            string expectedResult = "1, 2, 3, 44";

            //Act
            string resultingString = fakelist.ToString();

            //Assert
            Assert.AreEqual(expectedResult, resultingString);
        }

        [TestMethod]
        public void ToString_EmptyStringInList_SpaceInResultingString()
        {
            //Arrange
            FakeList<string> fakelist = new FakeList<string>() { "a", " ", "b" };
            string expectedResult = "a,  , b";

            //Act
            string resultingString = fakelist.ToString();

            //Assert
            Assert.AreEqual(expectedResult, resultingString);
        }

        [TestMethod]
        public void ToString_ListOfCustomCarClassObjects_CarClassToStringTestResult()
        {
            //Arrange
            Car car = new Car();
            FakeList<Car> fakelist = new FakeList<Car>();
            string expectedString = "ConsoleApplication3.Car";

            //Act
            fakelist.Add(car);
            string resultingString = fakelist.ToString();

            //Assert
            Assert.AreEqual(resultingString, expectedString);
        }

        //[TestMethod]          //If I have time: add functionality with arrays
        //public void ToString_ListOfArrays_EachArraySeparatedWithNewline()
        //{
        //    //Arrange
        //    FakeList<Array> fakelist = new FakeList<Array>();
        //    int[] x = new int[2];
        //    x[0] = 1;
        //    x[1] = 2;
        //    int[] y = new int[2] { 3, 4 };
        //    string expectedResult = "1, 2\n3, 4";

        //    //Act
        //    fakelist.Add(x);
        //    fakelist.Add(y);
        //    string resultingString = fakelist.ToString();

        //    //Assert
        //    Assert.AreEqual(expectedResult, resultingString);      
        //}
     
        [TestMethod]
        public void PlusOverload_IntegerLists_OnecombinedList()
        {
            //Arrange
            FakeList<int> firstFakeList = new FakeList<int>();
            int firstListZeroIndexValue = 1;
            int firstListOneIndexValue = 2;
            FakeList<int> secondFakeList = new FakeList<int>();
            int secondListZeroIndexValue = 3;
            int secondListOneIndexValue = 4;


            //Act
            firstFakeList.Add(firstListZeroIndexValue);
            firstFakeList.Add(firstListOneIndexValue);
            secondFakeList.Add(secondListZeroIndexValue);
            secondFakeList.Add(secondListOneIndexValue);
            FakeList<int> resultingList = firstFakeList + secondFakeList;
            //Assert
            Assert.AreEqual(secondListZeroIndexValue, resultingList[2]);
        }

        [TestMethod]
        public void PlusOverload_IntegerLists_OrderOfIntegersCorrect()
        {
            //Arrange
            FakeList<int> firstFakeList = new FakeList<int>() { 1, 2 };
            FakeList<int> secondFakeList = new FakeList<int>() { 3, 4 };
            int expectedThirdIndex = 3;

            //Act
            FakeList<int> resultingList = firstFakeList + secondFakeList;
            //Assert
            Assert.AreEqual(expectedThirdIndex, resultingList[2]);
        }
        [TestMethod]
        public void PlusOverload_IntegerListsSwitched_OrderOfIntegersStillCorrect()
        {
            //Arrange
            FakeList<int> secondFakeList = new FakeList<int>() { 1, 2 };
            FakeList<int> firstFakeList = new FakeList<int>() { 3, 4 };
            int expectedThirdIndex = 1;

            //Act
            FakeList<int> resultingList = firstFakeList + secondFakeList;
            //Assert
            Assert.AreEqual(expectedThirdIndex, resultingList[2]);
        }

        [TestMethod]
        public void PlusOverLoad_StringListsWithEmpty_CombinedListContainsSpace()
        {
            //Arrange
            FakeList<string> firstFakeList = new FakeList<string>() { "a", "b" };
            FakeList<string> secondFakeList = new FakeList<string>() { " ", "c" };
            string ExpectedThirdIndex = " ";
            
            //Act
            FakeList<string> resultingList = firstFakeList + secondFakeList;

            //Assert
            Assert.AreEqual(ExpectedThirdIndex, resultingList[2]);
        }

        [TestMethod]
        public void PlusOverload_DetermineNewListCount_SumOfInputListCounts()
        {
            //Arrange
            FakeList<string> firstFakeList = new FakeList<string>() { "a", "b" };
            FakeList<string> secondFakeList = new FakeList<string>() { " ", "c" };
            int fakelist1Count = 2;
            int fakelist2Count = 2;
            int expectedResultingCount = fakelist1Count+fakelist2Count;

            //Act
            FakeList<string> resultingList = firstFakeList + secondFakeList;
            int resultingCount = resultingList.Count;

            //Assert
            Assert.AreEqual(resultingCount, expectedResultingCount);
        }

        [TestMethod]
        public void MinusOverLoad_IntegerInListSubtracted_FirstInstanceGone()
        {
            //Arrange
            FakeList<int> firstFakeList = new FakeList<int>() { 1, 2, 3 };
            FakeList<int> secondFakeList = new FakeList<int>() {2};
            int expectedSecondIndexValue = 3;

            //Act
            FakeList<int> resultingFakeList = firstFakeList - secondFakeList;

            //Assert
            Assert.AreEqual(expectedSecondIndexValue, resultingFakeList[1]);
        }

        [TestMethod]
        public void MinusOverLoad_TwoIntegerInListSubtracted_BothIntegersRemoved()
        {
            //Arrange
            FakeList<int> firstFakeList = new FakeList<int>() { 1, 2, 3 };
            FakeList<int> secondFakeList = new FakeList<int>() { 1,2 };
            int expectedZeroIndexValue = 3;

            //Act
            FakeList<int> resultingFakeList = firstFakeList - secondFakeList;

            //Assert
            Assert.AreEqual(expectedZeroIndexValue, resultingFakeList[0]);
        }

        [TestMethod]
        public void MinusOverLoad_RepeatedIntegerInListSubtracted_SecondInstanceRemains()
        {
            //Arrange
            FakeList<int> firstFakeList = new FakeList<int>() { 1, 2, 2, 3 };
            FakeList<int> secondFakeList = new FakeList<int>() { 2};
            int valueExpectedSecondIndex = 2;

            //Act
            FakeList<int> resultingFakeList = firstFakeList - secondFakeList;

            //Assert
            Assert.AreEqual(valueExpectedSecondIndex, resultingFakeList[1]);
        }

        [TestMethod]
        public void MinusOverload_IntegerToRemoveDNE_FirstListUnchanged()
        {
            //Arrange
            FakeList<int> firstFakeList = new FakeList<int>() { 1, 2, 2, 3 };
            FakeList<int> secondFakeList = new FakeList<int>() { 6 };
            bool firstFakeListUnchanged = true;

            //Act
            FakeList<int> resultingList = firstFakeList - secondFakeList;
            for (int i = 0; i < resultingList.Count; i++)
            {
                if (resultingList[i] != firstFakeList[i])
                {
                    firstFakeListUnchanged = false;
                }
            }

            Assert.IsTrue(firstFakeListUnchanged);
        }


        [TestMethod]
        public void MinusOverLoad_ExistingStringSubtracted_FirstInstanceGone()
        {
            //Arrange
            FakeList<string> firstFakeList = new FakeList<string>() { "a", "b" };
            FakeList<string> secondFakeLIst = new FakeList<string>() { "a" };
            string expectedRemainingString = "b";

            //Act
            FakeList<string> resultingList = firstFakeList - secondFakeLIst;
            string resultingString = resultingList[0];

            //Assert
            Assert.AreEqual(expectedRemainingString, resultingString);
        }

        [TestMethod]
        public void MinusOverLoad_RepeatedStringSubtracted_SubsequentInstanceRemains()
        {
            //Arrange
            FakeList<string> firstFakeList = new FakeList<string>() { "a","a","a","b" };
            FakeList<string> listToSubtract = new FakeList<string>() { "a" };
            string expectedSecondIndexValue = "a";

            //Act
            FakeList<string> resultingFakeList = firstFakeList - listToSubtract;
            string resultingSecondIndexValue = resultingFakeList[1];

            //Assert
            Assert.AreEqual(expectedSecondIndexValue, resultingSecondIndexValue);

        }
        /* ZIP: for this project {1,2,3}.zip({4,5,6}) --> {1,4,2,5,3,6}
         The above line is what I refer to as "OneFourPattern"

        */

        [TestMethod]
        public void Zip_EqualCountIntegerLists_SecondListFirstIndexBecomesSecondIndexOfZipper()
        {
            //Arrange
            FakeList<int> firstFakeList = new FakeList<int>();//{1,2,3};
            FakeList<int> secondFakeList = new FakeList<int>();//{4,5,6};

            //Act
            firstFakeList.Add(1);
            firstFakeList.Add(2);
            firstFakeList.Add(3);
            secondFakeList.Add(4);
            secondFakeList.Add(5);
            secondFakeList.Add(6);
            FakeList<int> zippedList = firstFakeList.Zip(secondFakeList);

            //Assert
            Assert.AreEqual(secondFakeList[0], zippedList[1]);
        }
        
        [TestMethod]//To show {1,2,3}.Zip({4,5}) --> {1,4,2,5}
        public void Zip_SecondIntegerListCountLower_FirstListLosesItems()
        {
            //Arrange
            FakeList<int> firstFakeList = new FakeList<int>() { 1, 2, 3 };
            FakeList<int> secondFakeList = new FakeList<int>() { 4,5 };
            int expectedZippedListCount = 4;

            //Act
            FakeList<int> zippedList = firstFakeList.Zip(secondFakeList);

            //Assert
            Assert.AreEqual(expectedZippedListCount, zippedList.Count);
        }

        [TestMethod]
        public void Zip_StringListsWithUnequalCount_ResultingCountEqualsTwiceLowerCount()
        {
            //Arrange
            FakeList<string> firstFakeList = new FakeList<string>() { "a", "b", "c" };
            FakeList<string> secondFakeList = new FakeList<string>() { "a" };
            int firstListCount = firstFakeList.Count;
            int secondListCount = secondFakeList.Count;
            int shorterListCount;

            //Act
            FakeList<string> zippedList = firstFakeList.Zip(secondFakeList);
            if (firstListCount < secondListCount)
            {
                shorterListCount = firstListCount;
            }
            else 
            {
                shorterListCount = secondListCount;
            }
            int expectedZippedListCount = 2 * shorterListCount;
            //Assert
            Assert.AreEqual(expectedZippedListCount, zippedList.Count);
        }

    }
}


