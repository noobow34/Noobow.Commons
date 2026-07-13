using SlackNet;
using SlackNet.Blocks;

namespace Noobow.Commons.Utils
{
    public static class SlackUtil
    {
        private static ISlackApiClient? _slackClient;

        private static ISlackApiClient GetClient()
        {
            if (_slackClient == null)
            {
                string? token = Environment.GetEnvironmentVariable("SLACK_BOT_TOKEN");
                _slackClient = new SlackServiceBuilder()
                    .UseApiToken(token)
                    .GetApiClient();
            }
            return _slackClient;
        }

        public static async Task PostAsync(string channel, string text)
        {
            await GetClient().Chat.PostMessage(new SlackNet.WebApi.Message { Text = text, Channel = channel });
        }

        public static async Task PostAsync(string channel, string text, IList<Block> blocks)
        {
            await GetClient().Chat.PostMessage(new SlackNet.WebApi.Message { Text = text, Channel = channel, Blocks = blocks });
        }
    }
}
