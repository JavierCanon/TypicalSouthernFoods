using DevExpress.XtraScheduler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TypicalSouthernFoods.Webforms {

    public class SchedulerLabel {
        public long Id { get; set; }
        public string Name { get; set; }
        public string TextCssClass { get; set; }
        public string BackgroundCssClass { get; set; }
    }

    public class SchedulerAppointment {
        public long Id { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool AllDay { get; set; }
        public string Description { get; set; }
        public string RecurrenceInfo { get; set; }
        public int EventType { get; set; }
        public long LabelId { get; set; }
        public int Status { get; set; }
        public long? ResourceId { get; set; }
    }

    public class SchedulerResource {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public static class SchedulerLabelsHelper {
        private static List<SchedulerLabel> items;

        static SchedulerLabelsHelper() {
            items = new List<SchedulerLabel>();
            items.Add(new SchedulerLabel { Id = 1, Name = "Development", BackgroundCssClass = "bg-primary", TextCssClass = "text-white" });
            items.Add(new SchedulerLabel { Id = 2, Name = "Webinars", BackgroundCssClass = "bg-danger", TextCssClass = "text-white" });
            items.Add(new SchedulerLabel { Id = 3, Name = "Family", BackgroundCssClass = "bg-success", TextCssClass = "text-dark" });
            items.Add(new SchedulerLabel { Id = 4, Name = "Birthdays", BackgroundCssClass = "bg-primary", TextCssClass = "text-dark" });
        }

        public static List<SchedulerLabel> GetItems() {
            return items;
        }
    }


    public class AppointmentDataSourceHelper {

        static List<SchedulerAppointment> GetAppointments() { return DataProvider.GetSampleData(GenerateAppointments); }

        public static List<SchedulerAppointment> SelectMethodHandler() {
            return GetAppointments();
        }

        static List<SchedulerAppointment> GenerateAppointments() {
            List<SchedulerAppointment> list = new List<SchedulerAppointment>();

            int uniqueID = 0;
            DateTime startDate = DateTime.Now.Date;
            Random random = new Random();

            // Birthdays - from Contacts
            for(int i = 0; i < DataProvider.GetContacts().Count; i++) {
                Contact contact = DataProvider.GetContacts()[i];

                SchedulerAppointment appointment = new SchedulerAppointment();
                appointment.Id = uniqueID;
                appointment.Subject = contact.FirstName + " " + contact.LastName;
                appointment.AllDay = true;
                appointment.StartDate = contact.Birthday.Date;
                appointment.EndDate = appointment.StartDate.AddDays(1);
                appointment.EventType = (int)AppointmentType.Pattern; // Represents the appointment which serves as the pattern for the other recurring appointments
                appointment.LabelId = SchedulerLabelsHelper.GetItems().FirstOrDefault(c => c.Name == "Birthdays").Id; // Birthday label
                appointment.ResourceId = random.Next(1, ResourceDataSourceHelper.GetItems().Count + 1);

                RecurrenceInfo recInfo = new RecurrenceInfo();
                recInfo.Start = appointment.StartDate;
                recInfo.Range = RecurrenceRange.NoEndDate;
                recInfo.Type = RecurrenceType.Yearly;
                recInfo.Periodicity = 1;
                recInfo.Month = contact.Birthday.Month;
                recInfo.DayNumber = contact.Birthday.Day;
                appointment.RecurrenceInfo = recInfo.ToXml();

                list.Add(appointment);
                uniqueID++;
            }

            // Sample Appointments
            for(int i = -100; i < 100; i++) {
                if(i != 0 && i % random.Next(7, 10) == 0)
                    continue;

                SchedulerAppointment appointment = new SchedulerAppointment();
                appointment.Id = uniqueID;
                appointment.Subject = "Appointment " + uniqueID.ToString();
                int h = random.Next(7, 18);
                appointment.StartDate = startDate.AddDays(i).AddHours(h);
                appointment.EndDate = appointment.StartDate.AddHours(random.Next(2, 4));
                appointment.EventType = (int)AppointmentType.Normal; // Represents a standard (non-recurring) appointment
                appointment.LabelId = random.Next(1, 4);
                appointment.ResourceId = random.Next(1, ResourceDataSourceHelper.GetItems().Count + 1);
                appointment.Status = random.Next(1, 5);

                list.Add(appointment);
                uniqueID++;
            }

            return list;
        }

        public static object InsertMethodHandler(SchedulerAppointment newAppointment) {
            List<SchedulerAppointment> list = GetAppointments();
            newAppointment.Id = list.DefaultIfEmpty(newAppointment).Max(x => x.Id) + 1;
            list.Add(newAppointment);
            return newAppointment.Id; // DXCOMMENT: Return this value to the ASPxScheduler and set the ASPxScheduler.ASPxAppointmentStorage.AutoRetrieveId (https://documentation.devexpress.com/AspNet/DevExpress.Web.ASPxScheduler.ASPxAppointmentStorage.AutoRetrieveId.property) property to true.
        }

        public static void DeleteMethodHandler(SchedulerAppointment deletedAppointment) {
            GetAppointments().RemoveAll(x => x.Id.Equals(deletedAppointment.Id));
        }

        public static void UpdateMethodHandler(SchedulerAppointment updatedAppointment) {
            List<SchedulerAppointment> list = GetAppointments();
            SchedulerAppointment item = list.FirstOrDefault(i => i.Id.Equals(updatedAppointment.Id));

            item.AllDay = updatedAppointment.AllDay;
            item.Description = updatedAppointment.Description;
            item.StartDate = updatedAppointment.StartDate;
            item.EndDate = updatedAppointment.EndDate;
            item.EventType = updatedAppointment.EventType;
            item.LabelId = updatedAppointment.LabelId;
            item.Location = updatedAppointment.Location;
            item.RecurrenceInfo = updatedAppointment.RecurrenceInfo;
            item.Status = updatedAppointment.Status;
            item.Subject = updatedAppointment.Subject;
            item.ResourceId = updatedAppointment.ResourceId;
        }
    }

    public static class ResourceDataSourceHelper {
        private static List<SchedulerResource> items;

        static ResourceDataSourceHelper() {
            items = new List<SchedulerResource>();
            items.Add(new SchedulerResource { Id = 1, Name = "Calendar 1" });
            items.Add(new SchedulerResource { Id = 2, Name = "Calendar 2" });
            items.Add(new SchedulerResource { Id = 3, Name = "Calendar 3" });
            items.Add(new SchedulerResource { Id = 4, Name = "Calendar 4" });
            items.Add(new SchedulerResource { Id = 5, Name = "Calendar 5" });
            items.Add(new SchedulerResource { Id = 6, Name = "Calendar 6" });
            items.Add(new SchedulerResource { Id = 7, Name = "Calendar 7" });
            items.Add(new SchedulerResource { Id = 8, Name = "Calendar 8" });
        }

        public static List<SchedulerResource> GetItems() {
            return GetItems(null);
        }

        public static List<SchedulerResource> GetItems(List<long> ids) {
            if(ids == null)
                return items;
            return items.Where(item => ids.Contains(item.Id)).ToList();
        }
    }
}