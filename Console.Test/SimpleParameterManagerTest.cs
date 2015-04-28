using System;
using System.IO;
using Bastos.Console.Simple;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Console.Test
{
    [TestClass]
    public class SimpleParameterManagerTest
    {
        private static bool _passed;
        private static bool _passed2;

        [TestMethod]
        public void ArgCaseSensitive()
        {
            var args = new string[] { "arg1" };

            var manager = new SimpleParameterManager();
            manager.RegisterCommand<CommandStub>("arg1");

            SimpleParameterManagerTest._passed = false;
            manager.Process(args);

            Assert.IsTrue(SimpleParameterManagerTest._passed);
        }

        [TestMethod]
        public void ArgCaseInSensitive()
        {
            var args = new string[] { "ARG1" };

            var manager = new SimpleParameterManager(false);
            manager.RegisterCommand<CommandStub>("arg1");

            SimpleParameterManagerTest._passed = false;
            manager.Process(args);

            Assert.IsTrue(SimpleParameterManagerTest._passed);
        }

        [TestMethod]
        public void CustomActivator()
        {
            var args = new string[] { "arg1" };

            var manager = new SimpleParameterManager();

            manager.RegisterCommand("arg1", () => new CommandStub(true));

            SimpleParameterManagerTest._passed = false;
            SimpleParameterManagerTest._passed2 = false;
            manager.Process(args);

            Assert.IsTrue(SimpleParameterManagerTest._passed);
            Assert.IsTrue(SimpleParameterManagerTest._passed2);
        }

        [TestMethod]
        public void CommandNotFound()
        {
            var args = new string[] { "arg1NotExists" };

            var manager = new SimpleParameterManager();

            manager.RegisterCommand("arg1", () => new CommandStub(true));

            SimpleParameterManagerTest._passed = false;
            manager.Process(args);

            Assert.IsFalse(SimpleParameterManagerTest._passed);
        }

        [TestMethod]
        public void ManyCommands()
        {
            var args = new string[] { "arg1", "arg2" };

            var manager = new SimpleParameterManager();

            manager.RegisterCommand<CommandStub>("arg1");
            manager.RegisterCommand<CommandStub2>("arg2");

            SimpleParameterManagerTest._passed = false;
            SimpleParameterManagerTest._passed2 = false;
            manager.Process(args);

            Assert.IsTrue(SimpleParameterManagerTest._passed);
            Assert.IsTrue(SimpleParameterManagerTest._passed2);
        }

        [TestMethod]
        public void CheckPropertiCaseSensitive()
        {
            var manager = new SimpleParameterManager(true);
            Assert.IsTrue(manager.CaseSensitive);

            manager = new SimpleParameterManager(false);
            Assert.IsFalse(manager.CaseSensitive);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullArgNameRegister()
        {
            var manager = new SimpleParameterManager();
            manager.RegisterCommand<CommandStub>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullArgNameCustomRegister()
        {
            var manager = new SimpleParameterManager();
            manager.RegisterCommand("arg", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullArgProcess()
        {
            var manager = new SimpleParameterManager();
            manager.Process(null);
        }

        [TestMethod]
        public void CommandRegisterDescription()
        {
            var args = new string[] { "arg1" };

            var manager = new SimpleParameterManager();
            manager.RegisterCommand<CommandStub>("arg1", "Description");

            SimpleParameterManagerTest._passed = false;
            manager.Process(args);

            Assert.IsTrue(SimpleParameterManagerTest._passed);
        }

        [TestMethod]
        public void ShowHelp()
        {
            var manager = new SimpleParameterManager();
            manager.RegisterCommand<CommandStub>("arg1", "Description arg1");
            manager.RegisterCommand<CommandStub>("arg2", "Description arg2");

            MemoryStream mem = new MemoryStream();
            using (StreamWriter writer = new StreamWriter(mem))
            {
                System.Console.SetOut(writer);

                manager.ShowHelp();
            }

            var texto = System.Text.Encoding.Default.GetString(mem.ToArray());

            Assert.IsTrue(texto.Contains("arg1"));
            Assert.IsTrue(texto.Contains("arg2"));
            Assert.IsTrue(texto.Contains("Description arg1"));
            Assert.IsTrue(texto.Contains("Description arg2"));
        }

        private class CommandStub : ISimpleConsoleCommand
        {
            public CommandStub() { }

            public CommandStub(bool cutom)
            {
                SimpleParameterManagerTest._passed2 = true;
            }

            public void Execute()
            {
                SimpleParameterManagerTest._passed = true;
            }
        }

        private class CommandStub2 : ISimpleConsoleCommand
        {
            public CommandStub2() { }

            public void Execute()
            {
                SimpleParameterManagerTest._passed2 = true;
            }
        }
    }
}
