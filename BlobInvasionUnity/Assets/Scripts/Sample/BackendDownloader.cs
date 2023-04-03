using System.Threading.Tasks;

namespace BlobInvasion.Sample
{
    public class BackendDownloader 
    {
        private int _tryCount = 10;

        public async Task<bool> TryToConnectToServer()
        {
            bool result = false;
            int i = 0;

            do
            {
                //Try ping server each 1 second
                await Task.Delay(1000);

                /*
                if(serverResponced)
                {
                    result = true;
                    break;
                }
                 */

                i++;
            } while (i < _tryCount);

            return result;
        }
    }
}
