using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TypicalSouthernFoods.Webforms {

    public class Issue {
        public long Id { get; set; }
        public string Subject { get; set; }
        public Contact Customer { get; private set; }
        public long CustomerId
        {
            get { return Customer == null ? -1 : Customer.Id; }
            set { Customer = DataProvider.GetContacts().Find(contact => contact.Id == value); }
        }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Notes { get; set; }
        public bool Unread { get; set; }
        public bool IsDraft { get; set; }
        public bool IsArchived { get; set; }
        public int Kind { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public int Votes { get; set; }

        public Issue() {
            Kind = 1;
            IsDraft = true;
            Status = 1;
            Priority = 1;
            Customer = new Contact();
        }
        public void SetCustomer(Contact value) {
            Customer = value;
        }
        public void Assign(Issue src) {
            Subject = src.Subject;
            SetCustomer(src.Customer);
            Updated = DateTime.Now;
            Notes = src.Notes;
            IsDraft = src.IsDraft;
            IsArchived = src.IsArchived;
            Kind = src.Kind;
            Priority = src.Priority;
            Status = src.Status;
        }
    }

    public class Contact {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressBook { get; set; }
        public string Email { get; set; }
        public string PhotoFileName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }

        public string PhotoUrl { get { return string.Format("Content/Photo/{0}", PhotoFileName); } }
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
    }

    public class DashboardCard {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Value { get; set; }
        public string Summary { get; set; }
        public string Category { get; set; }
        public string ValueFormat { get; set; }

        public string ValueString { get { return string.IsNullOrEmpty(ValueFormat) ? Value.ToString() : string.Format(ValueFormat, Value); } }
        public string IconName { get { return "demo-icon demo-icon-" + GetIconName(); } }

        string GetIconName() {
            if(Value > 0)
                return "1";
            else if(Value < 0)
                return "2";
            else
                return "3";
        }
    }

    public static class DataProvider {
        static readonly object addIssueLockObject = new object();

        public static List<DashboardCard> GetDashboardCards() { return GetSampleData(GenerateDashboardCards); }
        public static List<Contact> GetContacts() { return GetSampleData(GenerateContacts); }
        public static List<Issue> GetIssues() { return GetSampleData(GenerateIssues); }

        public static List<T> GetSampleData<T>(Func<List<T>> generateData) {
            var session = HttpContext.Current.Session;
            var key = typeof(T).Name;
            List<T> result = session[key] as List<T>;
            if(result == null) {
                result = generateData();
                session[key] = result;
            }
            return result;
        }

        public static void AddNewIssue(Issue issue) {
            lock(addIssueLockObject) {
                List<Issue> issues = GetIssues();

                issue.Id = issues.DefaultIfEmpty(issue).Max(x => x.Id) + 1;
                issue.Created = DateTime.Now;
                issue.Updated = DateTime.Now;

                issues.Add(issue);
            }
        }
        public static void UpdateIssue(Issue issue) {
            var issueToUpdate = GetIssues().FirstOrDefault(i => i.Id == issue.Id);
            if(issueToUpdate != null)
                issueToUpdate.Assign(issue);
        }
        public static void DeleteIssues(List<long> ids) {
            GetIssues().RemoveAll(i => ids.Contains(i.Id));
        }
        static List<DashboardCard> GenerateDashboardCards() {
            var result = new List<DashboardCard>() {
                new DashboardCard() {
                     Id = 1, Category = "Company profitability", Summary = "+12% revenue increase", Title = "Sum", Value = 3000, ValueFormat = "{0}"
                },
                new DashboardCard() {
                     Id = 2, Category = "Company profitability", Summary = "+12% revenue increase", Title = "Unit", Value = 295, ValueFormat = "{0}"
                },
                new DashboardCard() {
                     Id = 3, Category = "Company profitability", Summary = "+12% revenue increase", Title = "Discount", Value = 0, ValueFormat = "{0}%"
                },
                new DashboardCard() {
                     Id = 4, Category = "Company profitability", Summary = "+50% revenue increase", Title = "Price", Value = 26000, ValueFormat = "{0}"
                },
                new DashboardCard() {
                     Id = 5, Category = "Company profitability", Summary = "+12% revenue increase", Title = "Sum", Value = 3000, ValueFormat = "{0}"
                },
                new DashboardCard() {
                     Id = 6, Category = "Company profitability", Summary = "+12% revenue increase", Title = "Unit", Value = 295, ValueFormat = "{0}"
                },
                new DashboardCard() {
                     Id = 7, Category = "Company profitability", Summary = "+12% revenue increase", Title = "Discount", Value = 0, ValueFormat = "{0}%"
                },
                new DashboardCard() {
                     Id = 8, Category = "Company profitability", Summary = "+50% revenue increase", Title = "Price", Value = 26000, ValueFormat = "{0}"
                }
            };
            return result;
        }
        static List<Contact> GenerateContacts() {
            List<Contact> contacts = new List<Contact> {

             new Contact {
              Id = 1, FirstName = "Naomi", LastName = "Moreno", AddressBook = "Personal", Email = "naomi.moreno@dx-email.com", PhotoFileName = "Naomi_Moreno.jpg", Country = "Australia", City = "Brisbane", Address = "918 Park Lane", Phone = "1 (11) 500 555-0",
              Birthday = new DateTime(1990, 1, 11)
             },
             new Contact {
              Id = 2, FirstName = "Logan", LastName = "Hernandez", AddressBook = "Personal", Email = "logan.hernandez@dx-email.com", PhotoFileName = "Logan_Hernandez.jpg", Country = "Australia", City = "Geelong", Address = "7625 Cloudview Dr.", Phone = "1 (11) 500 555-0", Birthday = new DateTime(1980, 2, 22)
             },
             new Contact {
              Id = 3, FirstName = "Heidi", LastName = "Lopez", AddressBook = "Business", Email = "heidi.lopez@dx-email.com", PhotoFileName = "Heidi_Lopez.jpg", Country = "Australia", City = "Matraville", Address = "2514 Via Cordona", Phone = "1 (11) 500 555-0", Birthday = new DateTime(1975, 3, 27)
             },
             new Contact {
              Id = 4, FirstName = "Rafael", LastName = "Raje", AddressBook = "Personal", Email = "rafael.raje@dx-email.com", PhotoFileName = "Rafael_Raje.jpg", Country = "Australia", City = "Hobart", Address = "5269 Mt. Trinity Court", Phone = "1 (11) 500 555-0", Birthday = new DateTime(1995, 4, 3)
             },
             new Contact {
              Id = 5, FirstName = "Jessie", LastName = "She", AddressBook = "Business", Email = "jessie.she@dx-email.com", PhotoFileName = "Jessie_She.jpg", Country = "Australia", City = "North Sydney", Address = "5866 Military E", Phone = "1 (11) 500 555-0", Birthday = new DateTime(1991, 5, 2)
             },
             new Contact {
              Id = 6, FirstName = "Alfredo", LastName = "Gomez", AddressBook = "Personal", Email = "alfredo.gomez@dx-email.com", PhotoFileName = "Alfredo_Gomez.jpg", Country = "Australia", City = "Port Macquarie", Address = "9430 La Vista Avenue", Phone = "1 (11) 500 555-0", Birthday = new DateTime(1976, 6, 7)
             },
             new Contact {
              Id = 7, FirstName = "Colin", LastName = "He", AddressBook = "Business", Email = "colin.he@dx-email.com", PhotoFileName = "Colin_He.jpg", Country = "Australia", City = "Seaford", Address = "3144 Via Rerrari", Phone = "1 (11) 500 555-0",
                Birthday = new DateTime(1972, 7, 18)
             },
             new Contact {
              Id = 8, FirstName = "Julia", LastName = "Bell", AddressBook = "Personal", Email = "julia.bell@dx-email.com", PhotoFileName = "Julia_Bell.jpg", Country = "Canada", City = "Vancouver", Address = "7516 Laguna Street", Phone = "1 (362) 555-0196",
              Birthday = new DateTime(1977, 7, 7)
             },
             new Contact {
              Id = 9, FirstName = "Katelyn", LastName = "Lopez", AddressBook = "Business", Email = "katelyn.lopez@dx-email.com", PhotoFileName = "Katelyn_Lopez.jpg", Country = "Canada", City = "Victoria", Address = "8873 Folson Drive", Phone = "1 (316) 555-0185", Birthday = new DateTime(1984, 8, 8)
             },
             new Contact {
              Id = 10, FirstName = "Nathan", LastName = "Bryant", AddressBook = "Personal", Email = "nathan.bryant@dx-email.com", PhotoFileName = "Nathan_Bryant.jpg", Country = "Canada", City = "Vancouver", Address = "7111 Stinson", Phone = "1 (161) 555-0172", Birthday = new DateTime(1993, 9, 9)
             },
             new Contact {
              Id = 11, FirstName = "Destiny", LastName = "Clark", AddressBook = "Business", Email = "destiny.clark@dx-email.com", PhotoFileName = "Destiny_Clark.jpg", Country = "Canada", City = "Westminster", Address = "6478 Pierce Ct", Phone = "1 (695) 555-0137", Birthday = new DateTime(1988, 10, 10)
             },
             new Contact {
              Id = 12, FirstName = "Diana", LastName = "Martin", AddressBook = "Personal", Email = "diana.martin@dx-email.com", PhotoFileName = "Diana_Martin.jpg", Country = "France", City = "Paris", Address = "9554, rue des Pyrenees", Phone = "1 (11) 500 555-0", Birthday = new DateTime(1986, 11, 11)
             },
             new Contact {
              Id = 13, FirstName = "Shannon", LastName = "Sanz", AddressBook = "Business", Email = "shannon.sanz@dx-email.com", PhotoFileName = "Shannon_Sanz.jpg", Country = "France", City = "Metz", Address = "74, rue Descartes", Phone = "1 (11) 500 555-0", Birthday = new DateTime(1974, 12, 12)
             },
             new Contact {
              Id = 14, FirstName = "Connor", LastName = "Jenkins", AddressBook = "Personal", Email = "connor.jenkins@dx-email.com", PhotoFileName = "Connor_Jenkins.jpg", Country = "Australia", City = "Newcastle", Address = "2542 Pinecrest Court", Phone = "1 (11) 500 555-0", Birthday = new DateTime(1977, 8, 26)
             },
             new Contact {
              Id = 15, FirstName = "Rebekah", LastName = "Raman", AddressBook = "Business", Email = "rebekah.raman@dx-email.com", PhotoFileName = "Rebekah_Raman.jpg", Country = "Australia", City = "Sydney", Address = "566 Morgan Territory Rd.", Phone = "1 (11) 500 555-0", Birthday = new DateTime(1995, 8, 21)
             },
             new Contact {
              Id = 16, FirstName = "Maria", LastName = "Hernandez", AddressBook = "Personal", Email = "maria.hernandez@dx-email.com", PhotoFileName = "Maria_Hernandez.jpg", Country = "Australia", City = "Wollongong", Address = "644 North Ranchford", Phone = "1 (11) 500 555-0", Birthday = new DateTime(1995, 5, 5)
             },
             new Contact {
              Id = 17, FirstName = "Martha", LastName = "Gao", AddressBook = "Business", Email = "martha.gao@dx-email.com", PhotoFileName = "Martha_Gao.jpg", Country = "Australia", City = "Sunshine", Address = "4060 Roundtree Court", Phone = "1 (11) 500 555-0", Birthday = new DateTime(1993, 6, 21)
             },
             new Contact {
              Id = 18, FirstName = "Clarence", LastName = "Nath", AddressBook = "Personal", Email = "clarence.nath@dx-email.com", PhotoFileName = "Clarence_Nath.jpg", Country = "Australia", City = "Coast", Address = "1591 Apple Court", Phone = "1 (11) 500 555-0", Birthday = new DateTime(1989, 9, 4)
             },
             new Contact {
              Id = 19, FirstName = "Gary", LastName = "Rubio", AddressBook = "Business", Email = "gary.rubio@dx-email.com", PhotoFileName = "Gary_Rubio.jpg", Country = "Australia", City = "Darwin", Address = "6532 Pinecrest Rd", Phone = "1 (11) 500 555-0",
              Birthday = new DateTime(1989, 9, 4)
             },
             new Contact {
              Id = 20, FirstName = "Alberto", LastName = "Alonso", AddressBook = "Personal", Email = "alberto.alonso@dx-email.com", PhotoFileName = "Alberto_Alonso.jpg", Country = "Australia", City = "Brisbane", Address = "1369 Rambling Lane", Phone = "1 (875) 555-0149", Birthday = new DateTime(1996, 6, 13)
             },
             new Contact {
              Id = 21, FirstName = "Jesse", LastName = "Gonzalez", AddressBook = "Business", Email = "jesse.gonzalez@dx-email.com", PhotoFileName = "Jesse_Gonzalez.jpg", Country = "Australia", City = "Townsville", Address = "5587 Stanley Dollar Dr.", Phone = "1 (228) 555-0146", Birthday = new DateTime(1987, 11, 12)
             },
             new Contact {
              Id = 22, FirstName = "Kevin", LastName = "Collins", AddressBook = "Personal", Email = "kevin.collins@dx-email.com", PhotoFileName = "Kevin_Collins.jpg", Country = "Australia", City = "Adelaide", Address = "7835 Rio Blanco Dr.", Phone = "1 (837) 555-0190", Birthday = new DateTime(1988, 2, 21)
             },
             new Contact {
              Id = 23, FirstName = "Julia", LastName = "Evans", AddressBook = "Business", Email = "julia.evans@dx-email.com", PhotoFileName = "Julia_Evans.jpg", Country = "Australia", City = "Hobart", Address = "9104 Jacobsen Street", Phone = "1 (910) 555-0138", Birthday = new DateTime(1979, 3, 3)
             },
             new Contact {
              Id = 24, FirstName = "Angela", LastName = "Murphy", AddressBook = "Personal", Email = "angela.murphy@dx-email.com", PhotoFileName = "Angela_Murphy.jpg", Country = "Australia", City = "Melbourne", Address = "4927 Virgil Street", Phone = "1 (451) 555-0162", Birthday = new DateTime(1972, 2, 2)
             },
             new Contact {
              Id = 25, FirstName = "Andrew", LastName = "Lee", AddressBook = "Business", Email = "andrew.lee@dx-email.com", PhotoFileName = "Andrew_Lee.jpg", Country = "Australia", City = "Geelong", Address = "2115 Pasado", Phone = "1 (992) 555-0120",
              Birthday = new DateTime(1971, 8, 8)
             },
             new Contact {
              Id = 26, FirstName = "Miguel", LastName = "Jones", AddressBook = "Personal", Email = "miguel.jones@dx-email.com", PhotoFileName = "Miguel_Jones.jpg", Country = "Australia", City = "Perth", Address = "8352 Turning View Cricle Drive", Phone = "1 (947) 555-0134", Birthday = new DateTime(1989, 11, 4)
             },
             new Contact {
              Id = 27, FirstName = "Connor", LastName = "Lopez", AddressBook = "Business", Email = "connor.lopez@dx-email.com", PhotoFileName = "Connor_Lopez.jpg", Country = "Australia", City = "Albany", Address = "9073 Mayda Way", Phone = "1 (666) 555-0112", Birthday = new DateTime(1981, 2, 1)
             },
             new Contact {
              Id = 28, FirstName = "Xavier", LastName = "Richardson", AddressBook = "Personal", Email = "xavier.richardson@dx-email.com", PhotoFileName = "Xavier_Richardson.jpg", Country = "Australia", City = "Canberra", Address = "3249 E Leland", Phone = "1 (578) 555-0132", Birthday = new DateTime(1982, 3, 15)
             },
             new Contact {
              Id = 29, FirstName = "Megan", LastName = "Sanchez", AddressBook = "Business", Email = "megan.sanchez@dx-email.com", PhotoFileName = "Megan_Sanchez.jpg", Country = "Australia", City = "Newcastle", Address = "1397 Paraiso Ct.", Phone = "1 (404) 555-0199", Birthday = new DateTime(1988, 6, 22)
             }
            };
            return contacts;
        }

        static List<Issue> GenerateIssues() {
            List<Issue> issues = new List<Issue> {
             new Issue {
              Id = 1, IsArchived = false, IsDraft = false, Subject = "DevAV Annual Performance Review", Unread = true, Kind = 1, Priority = 3, Status = 1, Notes = "Some notes for subject: DevAV Annual Performance Review", Votes = 1
             },
             new Issue {
              Id = 2, IsArchived = false, IsDraft = false, Subject = "DevAV Annual Performance Review", Unread = true, Kind = 1, Priority = 2, Status = 1, Notes = "Some notes for subject: DevAV Annual Performance Review", Votes = 1
             },
             new Issue {
              Id = 3, IsArchived = false, IsDraft = false, Subject = "Year End Financials", Unread = true, Kind = 2, Priority = 3, Status = 2, Notes = "Some notes for subject: Year End Financials", Votes = 1
             },
             new Issue {
              Id = 4, IsArchived = false, IsDraft = false, Subject = "Your NDA", Unread = false, Kind = 2, Priority = 2, Status = 2, Notes = "Some notes for subject: Your NDA", Votes = 0
             },
             new Issue {
              Id = 5, IsArchived = false, IsDraft = false, Subject = "Your NDA", Unread = false, Kind = 1, Priority = 3, Status = 2, Notes = "Some notes for subject: Your NDA", Votes = 16
             },
             new Issue {
              Id = 6, IsArchived = false, IsDraft = false, Subject = "Microsoft Surface Studio", Unread = true, Kind = 2, Priority = 2, Status = 2, Notes = "Some notes for subject: Microsoft Surface Studio", Votes = 3
             },
             new Issue {
              Id = 7, IsArchived = false, IsDraft = false, Subject = "DX-1200 Product Cut-Sheet", Unread = false, Kind = 1, Priority = 3, Status = 2, Notes = "Some notes for subject: DX-1200 Product Cut-Sheet", Votes = 4
             },
             new Issue {
              Id = 8, IsArchived = false, IsDraft = false, Subject = "HD Video Player Accessories", Unread = false, Kind = 2, Priority = 1, Status = 2, Notes = "Some notes for subject: HD Video Player Accessories", Votes = 0
             },
             new Issue {
              Id = 9, IsArchived = false, IsDraft = false, Subject = "HD Video Player Accessories", Unread = false, Kind = 2, Priority = 3, Status = 2, Notes = "Some notes for subject: HD Video Player Accessories", Votes = 18
             },
             new Issue {
              Id = 10, IsArchived = false, IsDraft = false, Subject = "Conference Room - Hotels in Germany", Unread = false, Kind = 2, Priority = 3, Status = 2, Notes = "Some notes for subject: Conference Room – Hotels in Germany", Votes = 6
             },
             new Issue {
              Id = 11, IsArchived = false, IsDraft = false, Subject = "Conference Room - Hotels in Germany", Unread = false, Kind = 1, Priority = 2, Status = 2, Notes = "Some notes for subject: Conference Room – Hotels in Germany", Votes = 7
             },
             new Issue {
              Id = 12, IsArchived = false, IsDraft = false, Subject = "Artwork for packaging", Unread = true, Kind = 2, Priority = 3, Status = 1, Notes = "Some notes for subject: Artwork for packaging", Votes = 0
             },
             new Issue {
              Id = 13, IsArchived = false, IsDraft = false, Subject = "Overdue Tasks", Unread = false, Kind = 2, Priority = 2, Status = 1, Notes = "Some notes for subject: Overdue Tasks", Votes = 12
             },
             new Issue {
              Id = 14, IsArchived = false, IsDraft = false, Subject = "Online Meeting", Unread = false, Kind = 1, Priority = 1, Status = 1, Notes = "Some notes for subject: Online Meeting", Votes = 9
             },
             new Issue {
              Id = 15, IsArchived = false, IsDraft = false, Subject = "Online Meeting", Unread = false, Kind = 1, Priority = 1, Status = 1, Notes = "Some notes for subject: Online Meeting", Votes = 4
             },
             new Issue {
              Id = 16, IsArchived = false, IsDraft = false, Subject = "Paris is Beautiful and Expensive", Unread = false, Kind = 2, Priority = 3, Status = 1, Notes = "Some notes for subject: Paris is Beautiful and Expensive", Votes = 4
             },
             new Issue {
              Id = 17, IsArchived = false, IsDraft = false, Subject = "Open Support Tickets", Unread = false, Kind = 1, Priority = 2, Status = 1, Notes = "Some notes for subject: Open Support Tickets", Votes = 2
             },
             new Issue {
              Id = 18, IsArchived = false, IsDraft = false, Subject = "Open Support Tickets", Unread = false, Kind = 2, Priority = 1, Status = 1, Notes = "Some notes for subject: Open Support Tickets", Votes = 0
             },
             new Issue {
              Id = 19, IsArchived = false, IsDraft = false, Subject = "Firmware Upgrade", Unread = false, Kind = 1, Priority = 3, Status = 1, Notes = "Some notes for subject: Firmware Upgrade", Votes = 4
             },
             new Issue {
              Id = 20, IsArchived = false, IsDraft = false, Subject = "A Few Quotes to Help with Motivation", Unread = false, Kind = 2, Priority = 3, Status = 1, Notes = "Some notes for subject: A Few Quotes to Help with Motivation", Votes = 3
             },
             new Issue {
              Id = 21, IsArchived = false, IsDraft = false, Subject = "Travel Per Diem and Reimbursements", Unread = false, Kind = 1, Priority = 1, Status = 2, Notes = "Some notes for subject: Travel Per Diem and Reimbursements", Votes = 2
             },
             new Issue {
              Id = 22, IsArchived = false, IsDraft = false, Subject = "Network Issues Remain Unresolved", Unread = false, Kind = 1, Priority = 2, Status = 1, Notes = "Some notes for subject: Network Issues Remain Unresolved", Votes = 6
             },
             new Issue {
              Id = 23, IsArchived = false, IsDraft = false, Subject = "Customer Feedback and Quotes About Our Service", Unread = false, Kind = 2, Priority = 3, Status = 2, Notes = "Some notes for subject: Customer Feedback and Quotes About Our Service", Votes = 7
             },
             new Issue {
              Id = 24, IsArchived = false, IsDraft = false, Subject = "Product Training and Continuing Education", Unread = false, Kind = 2, Priority = 1, Status = 1, Notes = "Some notes for subject: Product Training and Continuing Education", Votes = 0
             },
             new Issue {
              Id = 25, IsArchived = false, IsDraft = false, Subject = "Sales Opportunities Breakdown by Region", Unread = false, Kind = 2, Priority = 1, Status = 2, Notes = "Some notes for subject: Sales Opportunities Breakdown by Region", Votes = 6
             },
             new Issue {
              Id = 26, IsArchived = false, IsDraft = false, Subject = "Build Conference and SWAG", Unread = false, Kind = 1, Priority = 1, Status = 2, Notes = "Some notes for subject: Build Conference and SWAG", Votes = 6
             },
             new Issue {
              Id = 27, IsArchived = false, IsDraft = false, Subject = "Build Conference and SWAG", Unread = false, Kind = 1, Priority = 3, Status = 2, Notes = "Some notes for subject: Build Conference and SWAG", Votes = 1
             },
             new Issue {
              Id = 28, IsArchived = false, IsDraft = false, Subject = "DOL Consumer Report", Unread = false, Kind = 2, Priority = 2, Status = 1, Notes = "Some notes for subject: DOL Consumer Report", Votes = 4
             },
             new Issue {
              Id = 29, IsArchived = false, IsDraft = false, Subject = "Important: Data from the Bureau of Labor Statistics", Unread = false, Kind = 2, Priority = 3, Status = 2, Notes = "Some notes for subject: Important: Data from the Bureau of Labor Statistics", Votes = 3
             },
             new Issue {
              Id = 30, IsArchived = false, IsDraft = false, Subject = "People are Watching More TV", Unread = false, Kind = 1, Priority = 1, Status = 1, Notes = "Some notes for subject: People are Watching More TV", Votes = 8
             },
             new Issue {
              Id = 31, IsArchived = false, IsDraft = false, Subject = "A Question on Future Product Development", Unread = false, Kind = 1, Priority = 3, Status = 1, Notes = "Some notes for subject: A Question on Future Product Development", Votes = 9
             },
             new Issue {
              Id = 32, IsArchived = false, IsDraft = false, Subject = "A Question on Future Product Development", Unread = false, Kind = 2, Priority = 2, Status = 2, Notes = "Some notes for subject: A Question on Future Product Development", Votes = 0
             },
             new Issue {
              Id = 33, IsArchived = false, IsDraft = false, Subject = "Your Mailing Address", Unread = false, Kind = 2, Priority = 2, Status = 1, Notes = "Some notes for subject: Your Mailing Address", Votes = 6
             },
             new Issue {
              Id = 34, IsArchived = false, IsDraft = false, Subject = "Your Mailing Address", Unread = false, Kind = 1, Priority = 3, Status = 2, Notes = "Some notes for subject: Your Mailing Address", Votes = 13
             },
             new Issue {
              Id = 35, IsArchived = false, IsDraft = false, Subject = "New Circuit Board Design", Unread = false, Kind = 1, Priority = 1, Status = 2, Notes = "Some notes for subject: New Circuit Board Design", Votes = 5
             },
             new Issue {
              Id = 36, IsArchived = false, IsDraft = false, Subject = "New Power Supply and Overload Protection", Unread = false, Kind = 1, Priority = 1, Status = 2, Notes = "Some notes for subject: New Power Supply and Overload Protection", Votes = 1
             },
             new Issue {
              Id = 37, IsArchived = false, IsDraft = false, Subject = "Join Us for Lunch?", Unread = false, Kind = 2, Priority = 1, Status = 1, Notes = "Some notes for subject: Join Us for Lunch?", Votes = 6
             },
             new Issue {
              Id = 38, IsArchived = true, IsDraft = false, Subject = "My All-time Favorite Quote", Unread = false, Kind = 1, Priority = 3, Status = 2, Notes = "Some notes for subject: My All-time Favorite Quote", Votes = 7
             },
             new Issue {
              Id = 39, IsArchived = false, IsDraft = false, Subject = "I’m Getting Married", Unread = false, Kind = 1, Priority = 3, Status = 2, Notes = "Some notes for subject: I’m Getting Married", Votes = 0
             },
             new Issue {
              Id = 40, IsArchived = true, IsDraft = false, Subject = "Your Favorite Font", Unread = false, Kind = 2, Priority = 3, Status = 1, Notes = "Some notes for subject: Your Favorite Font", Votes = 8
             },
             new Issue {
              Id = 41, IsArchived = false, IsDraft = false, Subject = "Cabling and Termination", Unread = false, Kind = 2, Priority = 3, Status = 1, Notes = "Some notes for subject: Cabling and Termination", Votes = 5
             },
             new Issue {
              Id = 42, IsArchived = false, IsDraft = true, Subject = "Your Hard Work is Appreciated", Unread = false, Kind = 1, Priority = 2, Status = 1, Notes = "Some notes for subject: Your Hard Work is Appreciated", Votes = 0
             },
             new Issue {
              Id = 43, IsArchived = false, IsDraft = false, Subject = "Icons Icons and More Icons", Unread = false, Kind = 1, Priority = 3, Status = 2, Notes = "Some notes for subject: Icons Icons and More Icons", Votes = 8
             },
             new Issue {
              Id = 44, IsArchived = false, IsDraft = false, Subject = "Online Sales are Growing", Unread = false, Kind = 1, Priority = 2, Status = 1, Notes = "Some notes for subject: Online Sales are Growing", Votes = 8
             },
             new Issue {
              Id = 45, IsArchived = false, IsDraft = false, Subject = "Circuit Town Orders", Unread = false, Kind = 1, Priority = 1, Status = 1, Notes = "Some notes for subject: Circuit Town Orders", Votes = 3
             },
             new Issue {
              Id = 46, IsArchived = false, IsDraft = false, Subject = "Your Favorite Shakespeare Play", Unread = false, Kind = 1, Priority = 1, Status = 2, Notes = "Some notes for subject: Your Favorite Shakespeare Play", Votes = 2
             },
             new Issue {
              Id = 47, IsArchived = false, IsDraft = false, Subject = "My Favorite Resort in Las Vegas", Unread = false, Kind = 2, Priority = 3, Status = 2, Notes = "Some notes for subject: My Favorite Resort in Las Vegas", Votes = 6
             },
             new Issue {
              Id = 48, IsArchived = false, IsDraft = false, Subject = "Wikipedia Says I’m Right", Unread = false, Kind = 1, Priority = 1, Status = 1, Notes = "Some notes for subject: Wikipedia Says I’m Right", Votes = 0
             },
             new Issue {
              Id = 49, IsArchived = false, IsDraft = false, Subject = "Wikipedia Says I’m Right", Unread = false, Kind = 1, Priority = 1, Status = 2, Notes = "Some notes for subject: Wikipedia Says I’m Right", Votes = 15
             },
             new Issue {
              Id = 50, IsArchived = false, IsDraft = false, Subject = "Roy Orbison is my favorite", Unread = false, Kind = 1, Priority = 1, Status = 2, Notes = "Some notes for subject: Roy Orbison is my favorite", Votes = 4
             }
            };

            var rnd = new Random(Environment.TickCount);
            foreach(var i in issues) {
                i.SetCustomer(GetContacts()[rnd.Next(0, 29)]);
                i.Created = DateTime.Now.AddDays(-rnd.Next(1, 90) - 30);
                i.Updated = i.Created.AddDays(rnd.Next(1, 30));
            }
            return issues;
        }
    }
}