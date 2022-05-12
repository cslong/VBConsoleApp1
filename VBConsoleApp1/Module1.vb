
Imports System.Reflection
Imports System
Imports System.IO, System.Collections
Imports Newtonsoft.Json
Imports System.Web
Imports Microsoft.Owin.Security
Imports Microsoft.Owin.Security.Infrastructure
Imports Org.BouncyCastle.Security

Module Module1

    Sub Main()
        Console.WriteLine("Hello World")

        'this is a comment
        Dim num = Math.Abs(-1).ToString()

        Dim person As New Person()
        person.SetName("Chris")
        Console.WriteLine(person.Name)
        Console.WriteLine(person.GetName())

        Dim fileInput = Console.ReadLine()
        Dim jsonFile
        If fileInput IsNot "" Then
            jsonFile = fileInput
        Else
            jsonFile = "D:\\Users\\longachr\\Desktop\\porting-assistant-config.json"
        End If

        Dim request As New HttpRequest("", "http://localhost", "")

        Dim fileReader As New StreamReader(CStr(jsonFile))
        Dim fileText As String = fileReader.ReadToEnd()
        Dim portingAssistantConfig As PortingAssistantAppConfiguration = JsonConvert.DeserializeObject(Of PortingAssistantAppConfiguration)(fileText)
        Console.WriteLine(portingAssistantConfig.PortingAssistantMetrics.Region)

        Dim random = New SecureRandom()
        Console.WriteLine(random.Next())
        Console.ReadKey()
    End Sub

    Function OwinSecurityInfrastructure(create As AuthenticationTokenCreateContext, receive As AuthenticationTokenReceiveContext) As String
        Dim serializedTicket As String = create.SerializeTicket()
        create.SetToken("")
        receive.DeserializeTicket(serializedTicket)

        Dim helper As SecurityHelper = New SecurityHelper()
        helper.LookupChallenge("Authentication_Type", AuthenticationMode.Active)
        Return ""
    End Function

End Module
