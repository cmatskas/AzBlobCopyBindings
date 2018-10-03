using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace FunctionApp1
{
    public static class Function1
    {
        [FunctionName("CopyMyBlobYo")]
        public static void Run(
            [BlobTrigger("source/{name}", Connection ="SourceConnection")]Stream myBlob,
            [Blob("destination/{name}", FileAccess.Write, Connection="DestinationConnection")]Stream outputBlob,
            string name, TraceWriter log)
        {
            log.Info($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
            myBlob.CopyTo(outputBlob);
        }
    }
}
