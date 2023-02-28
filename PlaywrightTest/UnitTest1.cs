using Microsoft.Playwright.NUnit;

namespace TestExample;

public class Tests : PageTest
{
    [Test]
    [Order(1)]
    public async Task Test()
    {
        Page.Response += (o, response) =>
        {
            if (response.Status == 400)
                Assert.Fail();
        };

        await Page.GotoAsync("http://httpstat.us/200");
    }

    [Test]
    [Order(2)]
    public async Task Test1()
    {
        Page.Response += (o, response) =>
        {
            if (response.Status == 400)
                Assert.Fail();
        };

        var res = await Page.GotoAsync("http://httpstat.us/400");
    }


    [Test]
    [Order(3)]
    public async Task Test2()
    {
        await Page.GotoAsync("http://httpstat.us/500");

        Assert.That(true, Is.EqualTo(true));
    }
}