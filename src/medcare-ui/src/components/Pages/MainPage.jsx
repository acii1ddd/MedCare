import Footer from "../Layout/Footer";  

export default function MainPage() {
    return (
        <div className="bg-gray-50 min-h-screen flex flex-col mt-15">
            {/* Header Section */}
            <header className="bg-blue-600 text-white py-8 text-center">
                <h1 className="text-4xl font-bold">Добро пожаловать в Медцентр</h1>
                <p className="mt-2 text-lg">Забота о вашем здоровье — наша главная цель</p>
            </header>

            {/* Services Section */}
            <section className="px-6 py-12 bg-white">
                <div className="max-w-7xl mx-auto text-center">
                    <h2 className="text-3xl font-semibold text-gray-800">Наши Услуги</h2>
                    <p className="mt-4 text-lg text-gray-600">
                        Мы предлагаем широкий спектр медицинских услуг для вас и вашей семьи.
                    </p>
                    <div className="mt-8 grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
                        <div className="bg-blue-50 p-6 rounded-lg shadow-lg">
                            <h3 className="text-xl font-semibold text-blue-600">Консультации</h3>
                            <p className="mt-2 text-gray-600">
                                Опытные врачи помогут вам разобраться в любых вопросах здоровья.
                            </p>
                        </div>
                        <div className="bg-blue-50 p-6 rounded-lg shadow-lg">
                            <h3 className="text-xl font-semibold text-blue-600">Диагностика</h3>
                            <p className="mt-2 text-gray-600">
                                Современные диагностические процедуры для точных результатов.
                            </p>
                        </div>
                        <div className="bg-blue-50 p-6 rounded-lg shadow-lg">
                            <h3 className="text-xl font-semibold text-blue-600">Лечение</h3>
                            <p className="mt-2 text-gray-600">
                                Эффективные методы лечения, основанные на последних медицинских достижениях.
                            </p>
                        </div>
                    </div>
                </div>
            </section>

            {/* About Section */}
            <section className="px-6 py-12 bg-gray-100">
                <div className="max-w-7xl mx-auto text-center">
                    <h2 className="text-3xl font-semibold text-gray-800">О нас</h2>
                    <p className="mt-4 text-lg text-gray-600">
                        Мы — команда высококвалифицированных специалистов, стремящихся предоставить вам качественное
                        медицинское обслуживание в любое время.
                    </p>
                </div>
            </section>
            <Footer/>
        </div>
    );
}
