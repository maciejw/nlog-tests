﻿using System;
using System.Diagnostics;
using Xunit;

namespace Test1
{


    public class Log4NetTests : IDisposable
    {
        private readonly string AuditRepository;
        private readonly log4net.ILog logger;

        public Log4NetTests(Configuration configuration = null)
        {
            AuditRepository = LoggerBuilders.BuildLog4Net(configuration);

            logger = log4net.LogManager.GetLogger(AuditRepository, typeof(IAuditLogger));

        }

        [Fact]
        public void TestLog4Net()
        {
            TestsCases.TestCase1((message, i, data) => logger.Info(new { message, i, data }), (message, elapsedMilliseconds, count) => logger.Info(new { message, elapsedMilliseconds, count }));

        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    log4net.LogManager.ShutdownRepository(AuditRepository);
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

    }
}
