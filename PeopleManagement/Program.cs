﻿class Program
{
    static void Main(string[] args)
    {
        CsvParser parser = new CsvParser();
        List<Person> people = parser.Parse();

        PeopleReport report = new PeopleReport();
        report.SaveMales(people);
        report.SaveFemales(people);
        report.SaveDotComUsers(people);
    }
}