using Project.Testing.Helpers;
using Project.Testing.Resources;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TechTalk.SpecFlow;


namespace Project.Testing.TestDataConfig
{
    public interface ITestDataHelper
    {
        CreateCustomer CreateCustomerByTestScenario { get; }
        LongLiveToken LongLiveToken { get; }
        TokenCredential GetTokenCredentialsFromConfigFile(string name);
        string GetApiUrlFromConfigFile(string APIName, string APIvia);

        GetEntity GetEntitiesByTestScenario { get; }

        GetEntityAccount GetEntityAccountByTestScenario { get; }
        TransactionList GetTransactionListByTestScenario { get; }
        FundsTransfer GetFundsTransferByTestScenario { get; }
        BPay GetBpayByTestScenario { get; }
        TwoFactorAuthentication GetTwoFactorAuthenticationByTestScenario { get; }

        bool UseABCTestingHeader { get; }
        string ABCTestingHeaderValue { get; }
    }

    public class TestDataHelper : ITestDataHelper
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly TestDataConfig _testConfig;

        public TestDataHelper(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));

            var environment = ConfigurationManager.AppSettings["EnvironmentName"];
            var testDataResourceName = $"TestDataConfig.{environment}";

            // Prep Test Data Configuration
            var config = GetType().Assembly.GetJsonResource<TestDataConfig>(testDataResourceName);
            _testConfig = config;

            // Write some output
            if (string.IsNullOrEmpty(_testConfig.ABCTestingHeader))
                Console.WriteLine($"{nameof(ITestDataHelper)}: Registered without mock data");
            if (string.IsNullOrEmpty(_testConfig.ABCTestingHeader))
                Console.WriteLine($"{nameof(ITestDataHelper)}: Registered without mock data");
        }

        private string _testScenarioNumber => _scenarioContext.Get<string>(Constants.TestScenarioNumberKey);
        public CreateCustomer CreateCustomerByTestScenario => _testConfig.CreateCustomer.Single(s => s.Name == _testScenarioNumber);

        public string GetApiUrlFromConfigFile(string apiName, string apiVia) => _testConfig.ApiUrls.Single(s => s.Name == apiName).UriList
            .Single(s => s.Key == apiVia).Uri;

        public GetEntity GetEntitiesByTestScenario => _testConfig.GetEntities.Single(s => s.Name == _testScenarioNumber);
        public GetEntityAccount GetEntityAccountByTestScenario => _testConfig.GetEntityAccounts.Single(s => s.Name == _testScenarioNumber);

        public TransactionList GetTransactionListByTestScenario => _testConfig.TransactionList.Single(s => s.Name == _testScenarioNumber);

        public TokenCredential GetTokenCredentialsFromConfigFile(string name) => _testConfig.TokenCredentials.Single(s => s.Name == name);

        public LongLiveToken LongLiveToken => _testConfig.LongLiveToken;

        public FundsTransfer GetFundsTransferByTestScenario => _testConfig.FundsTransfer.Single(s => s.Name == _testScenarioNumber);

        public BPay GetBpayByTestScenario => _testConfig.BPay.Single(s => s.Name == _testScenarioNumber);

        public TwoFactorAuthentication GetTwoFactorAuthenticationByTestScenario => _testConfig.TwoFactorAuthentication.Single(s => s.Name == _testScenarioNumber);

        public string ABCTestingHeaderValue => _testConfig.ABCTestingHeader;
        public bool UseABCTestingHeader => !string.IsNullOrEmpty(_testConfig.ABCTestingHeader);
    }

    public class TestDataConfig
    {
        public string ABCTestingHeader { get; set; }
        public List<ApiUrl> ApiUrls { get; set; }
        public LongLiveToken LongLiveToken { get; set; }
        public List<TokenCredential> TokenCredentials { get; set; }
        public Token Token { get; set; }
        public List<TransactionList> TransactionList { get; set; }
        public List<GetEntity> GetEntities { get; set; }
        public List<GetEntityAccount> GetEntityAccounts { get; set; }
        public List<CreateCustomer> CreateCustomer { get; set; }
        public List<TwoFactorAuthentication> TwoFactorAuthentication { get; set; }
        public List<BPay> BPay { get; set; }
        public List<FundsTransfer> FundsTransfer { get; set; }
    }

    public class ApiUrl
    {
        public string Name { get; set; }
        public List<UriList> UriList { get; set; }
    }

    public class UriList
    {
        public string Key { get; set; }
        public string Uri { get; set; }
    }

    public class BPay
    {
        public string Name { get; set; }
        public string Channel { get; set; }
        public string ValidateBillerCodeOnly { get; set; }
        public string BillerCode { get; set; }
        public string BillerName { get; set; }
        public string BillerUsesVariableCrn { get; set; }
    }

    public class CreateCustomer
    {
        public string Name { get; set; }
        public string Can { get; set; }
        public string Pac { get; set; }
        public string AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MotherMaidenName { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string Clientid { get; set; }
        public string Clientsecret { get; set; }
        public string CredentialsType { get; set; }
        public string AccessCode { get; set; }
    }

    public class FundsTransfer
    {
        public string Name { get; set; }
        public string Channel { get; set; }
        public string CustomerNumber { get; set; }
        public string EntityNumber { get; set; }
        public string EntityType { get; set; }
        public string IsDelegate { get; set; }
        public string Bsb { get; set; }
        public string Frequency { get; set; }
        public string FrequencyCode { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string IsImmediatePayment { get; set; }
        public string ToAccountBsb { get; set; }
        public string ToAccountName { get; set; }
        public string ToAccountCurrency { get; set; }
        public string PaymentDescription { get; set; }
        public string PayerDescription { get; set; }
        public string PaymentType { get; set; }
        public string ValidateOnly { get; set; }
        public string IsFromNoticeAccount { get; set; }
        public string AccountNumber { get; set; }
        public string AccountCategory { get; set; }
        public string ToAccountNumber { get; set; }
        public string RequestId { get; set; }
    }

    public class GetEntity
    {
        public string Name { get; set; }
        public string Can { get; set; }
        public string FullName { get; set; }
        public string PersonalEmail { get; set; }
        public string MobileNumber { get; set; }
        public long EntityNumber { get; set; }
        public long AccountNumber { get; set; }
        public string AccountCategory { get; set; }
        public string AccountType { get; set; }
        public string Channel { get; set; }
        public string Language { get; set; }
        public string RequestId { get; set; }
        public string CustomerType { get; set; }
        public string EmailAddress { get; set; }
    }
    public class GetEntityAccount
    {
        public string Name { get; set; }
        public string Can { get; set; }
        public string Title { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string EntityNumber { get; set; }
        public string AccountNumber4Account1 { get; set; }
        public string AccountNumber4Account2 { get; set; }
        public string HowManyAccounts { get; set; }
        public string Bsb4Account1 { get; set; }
        public string Bsb4Account2 { get; set; }
        public string Branch4Account1 { get; set; }
        public string Branch4Account2 { get; set; }
        public string AccountCategory { get; set; }
        public string Channel { get; set; }
        public string Language { get; set; }
        public string Type { get; set; }
        public string Category4Account1 { get; set; }
        public string Category4Account2 { get; set; }
        public string CurrencyCode4Account1 { get; set; }
        public string CurrencyCode4Account2 { get; set; }
        public string ProductName4Account1 { get; set; }
        public string ProductName4Account2 { get; set; }
        public string RequestId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string Balance { get; set; }
        public string AccountType { get; set; }
        public string Bsb { get; set; }
        public List<Account> Accounts { get; set; }
        public string AccountTitle { get; set; }
        public string ServiceCodes { get; set; }
        public string CurrentBalance { get; set; }
        public string AvailableBalance { get; set; }
        public string ProductName { get; set; }
    }

    public class Account
    {
        public string AccountNumber { get; set; }
        public string AccountTitle { get; set; }
        public string Bsb { get; set; }
        public bool IsValid { get; set; }
    }

    public class LongLiveToken
    {
        public string BankfastAccountsLongLiveToken { get; set; }
        public string AemLongLiveToken { get; set; }
        public string BankfastAccountsExpiredToken { get; set; }
        public string AemExpiredToken { get; set; }
        public string InvalidToken { get; set; }
    }

    public class Token
    {
        public GetEntities GetEntities { get; set; }
    }

    public class GetEntities
    {
        public string BankFastMobileToken { get; set; }
        public string AemWebToken { get; set; }
        public string AemExpiredJwt { get; set; }
        public string BankFastxpiredJwt { get; set; }
        public string InValidBanfastJwt { get; set; }
        public string AeMcertPublicKey { get; set; }
        public string PrivateKey { get; set; }
    }

    public class TokenCredential
    {
        public string Name { get; set; }
        public string TokenCredentialClientId { get; set; }
        public string ClientSecret { get; set; }
        public string DeviceId { get; set; }
        public string DevicePin { get; set; }
        public string TokenCredentialScope { get; set; }
        public string Username { get; set; }
        public string CredentialsType { get; set; }
        public string AEMcertPublicKey { get; set; }
        public Uri AdTokenUrl { get; set; }
        public Uri Jwturl { get; set; }
        public string ClientId { get; set; }
        public string GrantType { get; set; }
        public string Scope { get; set; }
    }

    public class TransactionList
    {
        public string Name { get; set; }
        public string Can { get; set; }
        public string FullName { get; set; }
        public string PersonalEmail { get; set; }
        public string MobileNumber { get; set; }
        public string EntityNumber { get; set; }
        public string AccountNumber { get; set; }
        public string AccountCategory { get; set; }
        public string AccountType { get; set; }
        public string TransactionType { get; set; }
        public string Channel { get; set; }
        public string Language { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string RequestId { get; set; }
        public string MaxResult { get; set; }
        public string HostId { get; set; }
        public string HostSessionId { get; set; }
        public string Cursor { get; set; }
        public string RecordsSent { get; set; }
        public string Description { get; set; }
        public string IsTruncated { get; set; }
        public string TlItemVlaue { get; set; }
        public string TlItemBalance { get; set; }
        public string DebitOrCreditIndicator { get; set; }
        public string RecordsSentFirstCall { get; set; }
        public string RecordsSentSecondCall { get; set; }
        public string ReturnedCursor { get; set; }
        public string TransationRecordsFirstCall { get; set; }
        public string TransationRecordsSecondCall { get; set; }
        public string IsTruncatedSecondCall { get; set; }
        public string Vcd { get; set; }
        public string TransactionListDebitOrCreditIndicator { get; set; }
        public string Value { get; set; }
    }

    public class TwoFactorAuthentication
    {
        public string Name { get; set; }
        public string Can { get; set; }
        public string EntityNumber { get; set; }
        public string Channel { get; set; }
        public string Otp { get; set; }
    }

}