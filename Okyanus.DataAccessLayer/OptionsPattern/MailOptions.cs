﻿namespace Okyanus.DataAccessLayer.OptionsPattern
{
    public class MailOptions
    {
        public string MailName { get; set; }
        public string MailAdress { get; set; }
        public string MailAppKey { get; set; }
        public string MailService { get; set; }
        public int MailPort { get; set; }
        public bool MailSecurity { get; set; }
    }
}
//MailOptions mailoptions = _configuraiton.GetSection("MailOptions").Get<MailOprions>(); -> ile kullanılabilir ama bunu ıoc ye koyucua dependecy injection ile

//private readonly Teacher _teacher;

//public MyService(IOptions<Teacher> teacherOptions)
//{
//    _teacher = teacherOptions.Value;
//}

//public void SomeMethod()
//{
//    var name = _teacher.Name;
//    // ...
//}
