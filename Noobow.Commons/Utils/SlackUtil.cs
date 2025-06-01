using SlackNet;

namespace Noobow.Commons.Utils
{
    public static class SlackUtil
    {
        private static ISlackApiClient? _slackClient;
        public static async Task PostAsync(string channel, string text)
        {
            if (_slackClient == null)
            {
                string? token = Environment.GetEnvironmentVariable("SLACK_BOT_TOKEN");
                _slackClient = new SlackServiceBuilder()
                    .UseApiToken(token)
                    .GetApiClient();
            }
            await _slackClient.Chat.PostMessage(new SlackNet.WebApi.Message { Text = text, Channel = channel });
        }
    }
}
