using System.Activities;
using System.Collections.Immutable;
using UiPathTeam.Extensions.Activities;

namespace UiPathTeam.Extensions.Tests
{
	[TestClass]
	public class DictionaryUnitTests
	{
		[TestMethod]
		public void TestAddToDictionary()
		{
			var dictionary = new Dictionary<Object, Object>();
			var stringKey = "test key";
			var stringValue = "test value";

			var addToDictionaryActivity = new AddToDictionary
			{
				Dictionary = new InArgument<Dictionary<Object, Object>>((ctx) => dictionary),
				Key = new InArgument<Object>((ctx) => stringKey),
				Value = new InArgument<Object>((ctx) => stringValue)
			};

			WorkflowInvoker.Invoke(addToDictionaryActivity);

			Assert.AreEqual(stringValue, dictionary[stringKey]);
			Assert.AreEqual(1, dictionary.Count);

			stringKey = "another key";
			var integerValue = 32;

			addToDictionaryActivity = new AddToDictionary
			{
				Dictionary = new InArgument<Dictionary<Object, Object>>((ctx) => dictionary),
				Key = new InArgument<Object>((ctx) => stringKey),
				Value = new InArgument<Object>((ctx) => integerValue)
			};

			WorkflowInvoker.Invoke(addToDictionaryActivity);
			Assert.AreEqual(integerValue, dictionary[stringKey]);
			Assert.AreEqual(2, dictionary.Count);

			var integerKey = 42;
			stringValue = "the answer";

			addToDictionaryActivity = new AddToDictionary
			{
				Dictionary = new InArgument<Dictionary<Object, Object>>((ctx) => dictionary),
				Key = new InArgument<Object>((ctx) => integerKey),
				Value = new InArgument<Object>((ctx) => stringValue)
			};

			WorkflowInvoker.Invoke(addToDictionaryActivity);
			Assert.AreEqual(stringValue, dictionary[integerKey]);
			Assert.AreEqual(3, dictionary.Count);
		}

        [TestMethod]
        public void TestRemoveFromDictionary()
		{
            var dictionary = new Dictionary<Object, Object>();
			
            var stringKey = "test key";
            var stringValue = "test value";

			dictionary.Add(stringKey, stringValue);

            var removeFromDictionaryActivity = new RemoveFromDictionary
            {
                In_Dictionary = new InArgument<Dictionary<Object, Object>>((ctx) => dictionary),
                In_Key = new InArgument<Object>((ctx) => stringKey),
            };

            WorkflowInvoker.Invoke(removeFromDictionaryActivity);

			Assert.IsTrue(dictionary.Count == 0);
        }
        [TestMethod]
        public void TestDictionaryContainsValue()
        {
            var dictionary = new Dictionary<Object, Object>();
            var boolResult = true;
            var stringKey = "test key";
            var stringValue = "test value";


            dictionary.Add(stringKey, stringValue);

            var dictionaryContainsValue = new DictionaryContainsValue
            {
                Dictionary = new InArgument<Dictionary<Object, Object>>((ctx) => dictionary),
                Value = new InArgument<Object>((ctx) => stringValue),
                Result = new OutArgument<Boolean>((ctx) => boolResult),
            };

            WorkflowInvoker.Invoke(dictionaryContainsValue);

            Assert.IsTrue(boolResult);
        }

    }
}