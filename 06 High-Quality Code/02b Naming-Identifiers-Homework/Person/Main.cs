namespace Person
{
    public class Main
    {
        public void CreatePerson(int personID)
        {
            Person newPerson = new Person();
            newPerson.Age = personID;
            if (personID % 2 == 0)
            {
                newPerson.Name = "Male";
                newPerson.Sex = SexEnum.Male;
            }
            else
            {
                newPerson.Name = "Female";
                newPerson.Sex = SexEnum.Female;
            }
        }
    }
}