using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BetterGuid;

namespace SafeGuidTests
{
    [TestClass]
    public class SafeGuidTests
    {
        [TestMethod]
        public void TestInvalidStringDoesNotCauseException()
        {
            try
            {
                SafeGuid guid = new SafeGuid("FakeGuid");
            }
            catch
            {
                Assert.Fail("SafeGuid should not throw exceptions during creation");
            }
        }

        [TestMethod]
        public void TestGuidConstructorThrowsExceptionWithInvalidString()
        {
            try
            {
                Guid guid = new Guid("FakeGuid");
            }
            catch
            {
                return;
            }

            Assert.Fail("Guid construction with invalid string did not yield an exception.");
        }

        [TestMethod]
        public void TestGuidParseThrowsExceptionWithInvalidString()
        {
            try
            {
                Guid guid = Guid.Parse("FakeGuid");
            }
            catch
            {
                return;
            }

            Assert.Fail("Guid parsing with invalid string did not yield an exception.");
        }

        [TestMethod]
        public void TestInvalidStringGeneratesEmptyGuid()
        {
            SafeGuid guid = new SafeGuid("FakeGuid");

            Assert.AreEqual<Guid>(Guid.Empty, guid);
        }

        [TestMethod]
        public void TestSeparateSafeGuidsAreNotEqual()
        {
            SafeGuid firstGuid = new SafeGuid();
            SafeGuid secondGuid = new SafeGuid();

            Assert.IsFalse(firstGuid.Equals(secondGuid));
        }

        [TestMethod]
        public void TestGuidAndGeneratedSafeGuidHashToSameValue()
        {
            Guid guid = Guid.NewGuid();
            SafeGuid safeGuid = new SafeGuid(guid);

            Assert.AreEqual<int>(guid.GetHashCode(), safeGuid.GetHashCode());
        }

        [TestMethod]
        public void TestGuidAndGeneratedSafeGuidAreEqual()
        {
            Guid guid = Guid.NewGuid();
            SafeGuid safeGuid = new SafeGuid(guid);

            Assert.AreEqual<SafeGuid>(guid, safeGuid);
            Assert.AreEqual<Guid>(guid, safeGuid);
        }

        [TestMethod]
        public void TestSafeGuidAssignedToGuidRemainsValidGuid()
        {
            Guid guid = new SafeGuid();

            Assert.IsFalse(guid.Equals(Guid.Empty));
        }

        [TestMethod]
        public void TestGuidAndSafeGuidToStringAreTheSame()
        {
            Guid guid = Guid.NewGuid();
            SafeGuid safeGuid = new SafeGuid(guid);

            Assert.IsTrue(guid.ToString() == safeGuid.ToString());
        }

        [TestMethod]
        public void TestSafeGuidGeneratedFromValidStringIsValid()
        {
            Guid guid = Guid.NewGuid();
            SafeGuid safeGuid = new SafeGuid(guid.ToString());

            Assert.AreEqual<Guid>(safeGuid, guid);
        }

        [TestMethod]
        public void TestSafeGuidParseDoesNotThrowException()
        {
            try
            {
                SafeGuid guid = SafeGuid.Parse("FakeGuid");
            }
            catch
            {
                Assert.Fail("SafeGuid parsing should not yield any exceptions.");
            }
        }

        [TestMethod]
        public void TestSafeGuidParseYieldsSameResultAsConstruction()
        {
            Guid guid = Guid.NewGuid();
            Guid safeGuid = new SafeGuid(guid.ToString());
            Guid parsedGuid = SafeGuid.Parse(guid.ToString());

            Assert.AreEqual<Guid>(safeGuid, parsedGuid);
        }
    }
}
