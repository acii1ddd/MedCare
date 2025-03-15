document.getElementById("get-doctors").addEventListener("click", async () => {
    try {
        const branchName = "МЦ \"Свагушка\" в Гомеле";
        const response = await fetch(`https://localhost:7009/api/doctors/${branchName}`);
        const data = await response.json();


        document.getElementById("output").textContent = data[0].FirstName;
    } catch (error) {
        console.log("Ошибка при получении списка докторов ", error.message);
    }
});


// class Doctor {
//     constructor(firstName, lastName, patronymic, phoneNumber, specialization, image) {
//         this.firstName = firstName,
//         this.lastName = lastName,
//         this.patronymic = patronymic,
//         this.phoneNumber = phoneNumber,
//         this.specialization = specialization,
//         this.image = image,
//     }
// }