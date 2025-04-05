import { useContext } from 'react';
import { Link } from 'react-router-dom';
import { AuthContext } from '../Auth/AuthContext';

export default function Navbar() {
    const { currUser, logout } = useContext(AuthContext);

    return (
        <nav className="bg-white shadow-md px-6 py-3 flex justify-between items-center fixed top-0 left-0 w-full">
          <Link to="/" className="bg-blue-100 hover:bg-gray-400 text-2xl font-semibold text-black 
            px-6 py-3 rounded-xl shadow-lg transition duration-200">МЦ «Здоровье плюс»</Link>

          {/* Навигация */}
          <ul className="flex space-x-6 text-gray-700 font-medium">
            <li><Link to="/doctors" className="bg-gray-100 hover:bg-gray-300 text-xl text-black px-4 py-2 rounded-lg duration-150">Врачи</Link></li>
            <li><Link to="/services" className="bg-gray-100 hover:bg-gray-300 text-xl text-black px-4 py-2 rounded-lg duration-150">Услуги</Link></li>
            <li><Link to="/contacts" className="bg-gray-100 hover:bg-gray-300 text-xl text-black px-4 py-2 rounded-lg duration-150">Контакты</Link></li>
            
            {currUser && (
                <>
                  <li>
                    <Link to="/appointment" 
                      className="bg-blue-100 hover:bg-blue-300 text-xl text-black px-4 py-2 rounded-lg shadow-md transition duration-200">Запись на прием</Link>
                  </li>
                  <li>
                    <Link to="/dashboard" 
                      className="bg-blue-100 hover:bg-blue-300 text-xl text-black px-4 py-2 rounded-lg shadow-md transition duration-200">Мой кабинет</Link>
                  </li>
                </>
              )
            }
          </ul>

          {currUser ? (
            <div className='flex space-x-4'>
              <button className="bg-green-600 text-white px-4 py-2 rounded-lg hover:bg-green-700"
                      onClick={logout}>Выйти</button>
            </div>
          ) : (
            <div className="flex space-x-4"> 
              <Link to="/sign-in">
                <button className="bg-green-600 text-white px-4 py-2 rounded-lg hover:bg-green-700">
                  Войти
                </button>
              </Link>

              <button className="bg-green-600 text-white px-4 py-2 rounded-lg hover:bg-green-700">
                Зарегистрироваться
              </button>
            </div> 
          )}
        
        </nav>
    );
}