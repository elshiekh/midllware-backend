using System.Linq;
using System.Xml.Linq;
using elevatus_in.DTO;

namespace elevatus_in.Mapper
{
    public static class ObjectToXML
    {
        public static string ToXML(this P_APPLICANT_DETAILS employee)
        {
            XDocument P_APPLICANT_DETAILS = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),
            new XElement("EMPLOYEE",
                            new XElement("BUSINESS_GROUP_ID", employee.Employee.BUSINESS_GROUP_ID),
                            new XElement("APPLICANT_NUMBER", employee.Employee.APPLICANT_NUMBER),
                            new XElement("TITLE", employee.Employee.TITLE),
                            new XElement("FIRST_NAME", employee.Employee.FIRST_NAME),
                             new XElement("FATHER_NAME", employee.Employee.FATHER_NAME),
                            new XElement("GRANDFATHER_NAME", employee.Employee.GRANDFATHER_NAME),
                            new XElement("LAST_NAME", employee.Employee.LAST_NAME),
                            new XElement("FIRST_NAME_AR", employee.Employee.FIRST_NAME_AR),
                             new XElement("FATHER_NAME_AR", employee.Employee.FATHER_NAME_AR),
                            new XElement("GRANDFATHER_NAME_AR", employee.Employee.GRANDFATHER_NAME_AR),
                            new XElement("LAST_NAME_AR", employee.Employee.LAST_NAME_AR),
                            new XElement("GENDER", employee.Employee.GENDER),
                             new XElement("DATE_OF_BIRTH", employee.Employee.DATE_OF_BIRTH),
                            new XElement("MARITAL_STATUS", employee.Employee.MARITAL_STATUS),
                            new XElement("EMAIL_ADDRESS", employee.Employee.EMAIL_ADDRESS),
                             new XElement("MOBILE_NUMBER", employee.Employee.MOBILE_NUMBER),
                            new XElement("BLOOD_TYPE", employee.Employee.BLOOD_TYPE),
                             new XElement("NATIONALITY", employee.Employee.NATIONALITY),
                            new XElement("NATIONAL_IDENTIFIER", employee.Employee.NATIONAL_IDENTIFIER),
                            new XElement("EDUCATION_LEVEL", employee.Employee.EDUCATION_LEVEL),
                            new XElement("HIRE_DATE", employee.Employee.HIRE_DATE),
                             new XElement("ID_ISSUE_DATE", employee.Employee.ID_ISSUE_DATE),
                            new XElement("EMER_CONTACT_PER", employee.Employee.EMER_CONTACT_PER),
                            new XElement("EMER_CONTACT_PHONE", employee.Employee.EMER_CONTACT_PHONE),
                            new XElement("DISABILITY_FLAG", employee.Employee.DISABILITY_FLAG),
                             new XElement("STUDENT_FLAG", employee.Employee.STUDENT_FLAG),
                            new XElement("HRDF_FLAG", employee.Employee.HRDF_FLAG),
                            new XElement("RECRUITMENT_SOURCE", employee.Employee.RECRUITMENT_SOURCE),
                            new XElement("RECRUITER_EMP_NUM", employee.Employee.RECRUITER_EMP_NUM),
                             new XElement("WORK_ASSIGNMENT_FORM", employee.Employee.WORK_ASSIGNMENT_FORM),
                            new XElement("POSITION_ID", employee.Employee.POSITION_ID),
                            new XElement("EMPLOYEMENT_CATEGORY", employee.Employee.EMPLOYEMENT_CATEGORY),
                             new XElement("SUPERVISOR_ID", employee.Employee.SUPERVISOR_ID),
                            new XElement("PROBATION_PERIOD", employee.Employee.PROBATION_PERIOD),
                            new XElement("PROBATION_UNIT", employee.Employee.PROBATION_UNIT),
                            new XElement("NOTICE_PERIOD", employee.Employee.NOTICE_PERIOD),
                             new XElement("NOTICE_PERIOD_UOM", employee.Employee.NOTICE_PERIOD_UOM),
                            new XElement("PAY_BASIS_ID", employee.Employee.PAY_BASIS_ID),
                            new XElement("ANNUITIES", employee.Employee.ANNUITIES),
                            new XElement("ANNUITIES_JOINING_DATE", employee.Employee.ANNUITIES_JOINING_DATE),
                            new XElement("HAZARDS", employee.Employee.HAZARDS),
                            new XElement("HAZARDS_JOINING_DATE", employee.Employee.HAZARDS_JOINING_DATE),
                            new XElement("MOQEEM_STATUS", employee.Employee.MOQEEM_STATUS),
                            new XElement("BENEFIT_GROUP", employee.Employee.BENEFIT_GROUP),
                             new XElement("CONTRACT_MAT_STATUS", employee.Employee.CONTRACT_MAT_STATUS),
                            new XElement("TICKET_ROUTE", employee.Employee.TICKET_ROUTE),
                            new XElement("DOC_QUALIFICATION", employee.Employee.DOC_QUALIFICATION),
                            new XElement("GOSI_EMPLOYER", employee.Employee.GOSI_EMPLOYER),
                             new XElement("GOSI_NUM", employee.Employee.GOSI_NUM),
                            new XElement("HOUSING_TYPE", employee.Employee.HOUSING_TYPE),
                            new XElement("TRANS_TYPE", employee.Employee.TRANS_TYPE),
                            new XElement("BASIC_SALARY", employee.Employee.BASIC_SALARY),
                             new XElement("HOUSING_ALLOWANCE", employee.Employee.HOUSING_ALLOWANCE),
                            new XElement("COLA_ALLOWANCE", employee.Employee.COLA_ALLOWANCE),
                            new XElement("FOOD_ALLOWANCE", employee.Employee.FOOD_ALLOWANCE),
                            new XElement("TELEPHONE_ALLOWANCE", employee.Employee.TELEPHONE_ALLOWANCE),
                            new XElement("SUBSIDIARY_ALLOWANCE", employee.Employee.SUBSIDIARY_ALLOWANCE),
                            new XElement("CRITICAL_ALLOWANCE", employee.Employee.CRITICAL_ALLOWANCE),
                            new XElement("OVERRIDE_CRITICAL_ALLOWANCE", employee.Employee.OVERRIDE_CRITICAL_ALLOWANCE),
                            new XElement("SPECIAL_ALLOWANCE", employee.Employee.SPECIAL_ALLOWANCE),
                            new XElement("OVERRIDE_SPECIAL_ALLOWANCE", employee.Employee.OVERRIDE_SPECIAL_ALLOWANCE),
                            new XElement("ADMIN_PROF_ALLOWANCE", employee.Employee.ADMIN_PROF_ALLOWANCE),
                             new XElement("EXTRA_TASK_ALLOWANCE", employee.Employee.EXTRA_TASK_ALLOWANCE),
                             new XElement("DR_PROFISSIONAL", employee.Employee.DR_PROFISSIONAL),
                             new XElement("DR_MGI", employee.Employee.DR_MGI),
                             new XElement("DR_SPECIALITY", employee.Employee.DR_SPECIALITY),
                             new XElement("DR_SPECIALITY_DESC", employee.Employee.DR_SPECIALITY_DESC),
                             new XElement("PROJECT_ALLOWANCE", employee.Employee.PROJECT_ALLOWANCE),
                             new XElement("TRANS_ALLOWANCE", employee.Employee.TRANS_ALLOWANCE),
                             new XElement("OVERTIME", employee.Employee.OVERTIME),
                             new XElement("RELIGION", employee.Employee.RELIGION),
                             new XElement("PASSPORT_NUMBER", employee.Employee.PASSPORT_NUMBER),
                             new XElement("PASS_PROFESSION", employee.Employee.PASS_PROFESSION),
                            new XElement("PAAS_ISSUE_DATE", employee.Employee.PAAS_ISSUE_DATE),
                            new XElement("PASS_EXPIRY_DATE", employee.Employee.PASS_EXPIRY_DATE),
                            new XElement("PASS_PLACE_OF_ISSUE", employee.Employee.PASS_PLACE_OF_ISSUE),
                            new XElement("RECRUITMENT_AGENCY", employee.Employee.RECRUITMENT_AGENCY),
                            new XElement("TICKET_EXPENSE", employee.Employee.TICKET_EXPENSE),
                            new XElement("VISA_EXPENSE", employee.Employee.VISA_EXPENSE),
                            new XElement("EMPLOYER_SHARE", employee.Employee.EMPLOYER_SHARE),
                            new XElement("EMPLOYEE_SHARE", employee.Employee.EMPLOYEE_SHARE),
                            new XElement("NO_OF_INSTALLMENT", employee.Employee.NO_OF_INSTALLMENT),
                            new XElement("TICKET_ENTITLEMENT", employee.Employee.TICKET_ENTITLEMENT),
                            new XElement("ANNUAL_VAC_DAYS", employee.Employee.ANNUAL_VAC_DAYS),
                            new XElement("REC_RECOVERY_PERIOD", employee.Employee.REC_RECOVERY_PERIOD),
                            new XElement("CASH_ADVNACE_AMOUNT", employee.Employee.CASH_ADVNACE_AMOUNT),
                            new XElement("CASH_COMMENTS", employee.Employee.CASH_COMMENTS),
                            new XElement("CASH_RECOVERY_PERIOD", employee.Employee.CASH_RECOVERY_PERIOD)
            ));

            return P_APPLICANT_DETAILS.ToString();
        }

        //public static string To_BOOKED_ORDERSXML(this P_BOOKED_ORDERS_XML bookorders)
        //{
        //    XDocument P_IBOOKED_ORDERS_TBL = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
        //    new XElement("P_BOOKED_ORDERS_XML",
        //            from book_Order in bookorders.BOOKED_ORDERS
        //            select new XElement("BOOKED_ORDERS",
        //                    new XElement("VIDA_ID", book_Order.VIDA_ID),
        //                    new XElement("USER_NAME", book_Order.USER_NAME),
        //                    new XElement("ORDER_NUMBER", book_Order.ORDER_NUMBER),
        //                    new XElement("ORDER_DATE", book_Order.ORDER_DATE.ToShortDateString()),
        //                    new XElement("LINE_NUMBER", book_Order.LINE_NUMBER),
        //                    new XElement("ITEM_CODE", book_Order.ITEM_CODE),
        //                    new XElement("QUANTITY", book_Order.QUANTITY),
        //                    new XElement("NEED_BY_DATE", book_Order.NEED_BY_DATE.ToShortDateString()),
        //                    new XElement("DEST_ORGANIZATION_CODE", book_Order.DEST_ORGANIZATION_CODE),
        //                    new XElement("DEST_SUBINVENTORY", book_Order.DEST_SUBINVENTORY),
        //                    new XElement("EXTENSION_NUMBER", book_Order.EXTENSION_NUMBER)
        //                    )
        //    ));

        //    return P_IBOOKED_ORDERS_TBL.ToString();
        //}
    }
}
