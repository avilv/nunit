// ***********************************************************************
// Copyright (c) 2019 Charlie Poole, Rob Prouse
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace NUnit.TestData.LifeCycleTests
{
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class MultipleLifeCycleTestFixtureSetUpAttributes
    {
        [OneTimeSetUp]
        public void Init1()
        {
        }

        [OneTimeSetUp]
        public void Init2()
        {
        }

        [Test]
        public void OneTest()
        {
        }
    }

    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class  MultipleLifeCycleTestFixtureTearDownAttributes
    {
        [OneTimeTearDown]
        public void Destroy1()
        {
        }

        [OneTimeTearDown]
        public void Destroy2()
        {
        }

        [Test]
        public void OneTest()
        {
        }
    }

    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class MultipleOneTimeSetupTearDownLifeCycleTestFixture
    {
        public int SetUpCount = 0;
        public int TearDownCount = 0;

        [OneTimeSetUp]
        public void Setup()
        {
            SetUpCount++;
        }

        [OneTimeSetUp]
        public void Setup2()
        {
            SetUpCount++;
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            TearDownCount++;
        }

        [OneTimeTearDown]
        public void TearDown2()
        {
            TearDownCount++;
        }

        [Test]
        public void Test1() { }

        [Test]
        public void Test2() { }
    }

    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class SetupTearDownLifeCycleTestFixture
    {
        public int SetUpCount = 0;
        public int TearDownCount = 0;

        [SetUp]
        public void Setup()
        {
            SetUpCount++;
        }

        [TearDown]
        public void TearDown()
        {
            TearDownCount++;
        }

        [Test]
        public void Test1() { }

        [Test]
        public void Test2() { }
    }


    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class OneTimeSetupTearDownLifeCycleTestFixture
    {
        public int SetUpCount = 0;
        public int TearDownCount = 0;

        [OneTimeSetUp]
        public void Setup()
        {
            SetUpCount++;
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            TearDownCount++;
        }
 
        [Test]
        public void Test1() { }

        [Test]
        public void Test2() { }
    }

    [TestFixture]
    public class CountingLifeCycleTestFixture
    {
        public int Count { get; set; }

        [Test]
        public void CountIsAlwaysOne()
        {
            Count++;
            Assert.AreEqual(1, Count);
        }

        [Test]
        public void CountIsAlwaysOne_2()
        {
            Count++;
            Assert.AreEqual(1, Count);
        }
    }

    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class DisposableLifeCycleFixtureInstancePerTestCase : IDisposable
    {
        public static int DisposeCalls { get; set; }

        [Test]
        public void TestCase1()
        {

        }

        [Test]
        public void TestCase2()
        {

        }

        public void Dispose()
        {
            DisposeCalls++;
        }
    }
    
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class RepeatingLifeCycleFixtureInstancePerTestCase
    {
        public int Counter { get; set; }
        public static int RepeatCounter { get; set; }

        [Test]
        [Repeat(3)]
        public void CounterShouldAlwaysStartAsZero()
        {
            Counter++;
            RepeatCounter++;
            Assert.That(Counter, Is.EqualTo(1));
        }
    }
}
