using System;
using TechTalk.SpecFlow;

namespace Project.Testing.StepDefinitions
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private readonly ScenarioContext _scenarioContext;

        public SpecFlowFeature1Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
        }
    }
}
