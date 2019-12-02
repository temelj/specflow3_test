using System;
using TechTalk.SpecFlow;

namespace Project.Testing.StepDefinitions
{

    [Binding]
    public class SpecFlowFeature2Steps
    {
        private readonly ScenarioContext _scenarioContext;

        public SpecFlowFeature2Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
        }

        [Given(@"I have entered (.*) and (.*) into the tool")]
        public void GivenIHaveEnteredAndIntoTheTool(int p0, int p1)
        {
        }

        [When(@"I press combine")]
        public void WhenIPressCombine()
        {
        }

        [Then(@"the result should be (.*) on the monitor")]
        public void ThenTheResultShouldBeOnTheMonitor(int p0)
        {
        }

    }
}