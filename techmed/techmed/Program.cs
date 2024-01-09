using Techmed.Model;

var db = new TechmedContext();


var medic = new Medic{
    Name = "House",
    Age = 56,
    Crm = "123456",
    Specialty = "Cardiologista",
    Wage = 13000,
};

// var medic02 = new Medic{
//     Name = "Dexter",
//     Age = 64,
//     Crm = "848293",
//     Specialty = "Neurologista",
//     Wage = 17000,
// };
db.Medics.Add(medic);
// db.Medics.Add(medic02);

db.SaveChanges();

db.Medics.ToList().ForEach(medic => Console.WriteLine(medic.Name));
