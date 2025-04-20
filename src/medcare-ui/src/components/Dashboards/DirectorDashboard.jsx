import { useContext, useEffect, useState } from "react";
import { AuthContext } from "../Auth/AuthContext";
import Footer from '../Layout/Footer';
import { Link } from "react-router-dom";
import { GetAllForPatient } from "../../services/appointments.js";
import Worker from "../Items/Worker.jsx";

const DirectorDashboard = () => {
    const { currUser } = useContext(AuthContext);
    const [workers, setWorkers] = useState([]);

    // useEffect(() => {
    //     const fetchWorkers = async () => {
    //         const appointments = await GetAllForPatient(currUser.id);
    //         setWorkers(appointments);
    //     };

    //     fetchWorkers();
    // }, [currUser.id]);

    const tempWorkers = [
      {
        "id": "02937e0a-9190-49e4-8a8d-b86960926e1d",
        "firstName": "Александр",
        "lastName": "Иванов",
        "patronymic": "Сергеевич",
        "birthDate": "1990-05-14T21:00:00Z",
        "gender": 0,
        "email": "ivanov@gmail.com",
        "phoneNumber": "+375291234567",
        "image": "",
        "passportNumber": "5678903",
        "passportSeries": "HB",
        "role": "Director",
        "specializationName": null,
        "branch": {
          "name": "Gomel",
          "fullAddress": "Гомель, просп. Победы 55"
        },
        "schedules": []
      },
      {
        "id": "ab12cd34-ef56-7890-ab12-cd34ef567890",
        "firstName": "Мария",
        "lastName": "Петрова",
        "patronymic": "Игоревна",
        "birthDate": "1988-03-22T21:00:00Z",
        "gender": 1,
        "email": "petrova@gmail.com",
        "phoneNumber": "+375291234568",
        "image": "",
        "passportNumber": "1234567",
        "passportSeries": "MP",
        "role": "Receptionist",
        "specializationName": null,
        "branch": {
          "name": "Minsk",
          "fullAddress": "Минск, ул. Немига 12"
        },
        "schedules": []
      }
    ];

    setWorkers(tempWorkers);

    const deleteClickHandler = async (id) => {
      alert("Сотрудник успешно удален");
      //await Delete(id);
    };

    return (
        <div className="mt-15">
            <div className="bg-gray-50 min-h-screen flex flex-col">
            <header className="bg-emerald-600 text-white py-8 text-center">
                <h1 className="text-4xl font-bold">
                    Добро пожаловать, {currUser.firstName} {currUser.lastName} {currUser.patronymic}!
                </h1>
            </header>

            <section className="px-6 pt-12">
              <div className="max-w-7xl mx-auto text-center">
                <h2 className="text-3xl font-semibold text-gray-800 text-left">Регистратура</h2>
                <p className="text-lg text-gray-600 text-left">
                  Здесь вы можете управлять сотрудниками медицинского центра.   
                </p>
              </div>
            </section>

            <section className="px-6 py-15 bg-white">
                <div className="max-w-7xl mx-auto">
                    <div className="flex items-center justify-between flex-wrap gap-4 mb-6">
                      <h2 className="text-left text-3xl font-semibold text-gray-800 text-center">Сотрудники</h2>

                      <Link
                          to="/add-worker"
                          className="inline-block bg-emerald-600 hover:bg-emerald-700 text-white text-lg font-medium py-2 px-4 rounded-lg transition duration-200"
                      >
                          Добавить сотрудника
                      </Link>
                    </div>

                    <div className="mt-8 space-y-6">
                        {workers && workers.length > 0 ? (
                            workers.map((worker) => (
                                <Worker key={worker.id} worker={worker} onDeleteClick={deleteClickHandler}/>
                        ))
                        ) : (
                        <div
                            className="p-6 bg-gray-50 rounded-lg shadow hover:shadow-md transition"
                        >
                            <p className="text-center text-xl font-semibold">Нет данных о сотрудниках</p>
                        </div>
                        )}
                    </div>
                </div>
            </section>
            
            <Footer />
            </div>
        </div>
    );
}

export default DirectorDashboard;
