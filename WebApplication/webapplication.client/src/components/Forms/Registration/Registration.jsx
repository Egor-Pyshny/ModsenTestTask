import './Registration.css'

export const Registration = () =>{

    const handleSubmit = (e) => {
        const formDictionary = { ...e.target };
        var data = new Map();
        for (var i = 0; i < 5; i++) {
            data.set(formDictionary[i].name, formDictionary[i].value)
        }
        const myJson = JSON.stringify(Object.fromEntries(data));
        fetch("/api/v1.0/user", {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: myJson
        })
            .then(response => {
                if (response.status == 201) {
                    console.log('Запрос успешно выполнен');
                } else {
                    console.error('Ошибка при выполнении запроса');
                }
            })
            .catch(error => {
                console.error(error);
            });
    }

    return (
        <form id='registerForm' className="registerСontainer" onSubmit={handleSubmit}>

            <label htmlFor="firstName">Имя</label>
            <input type="text" id="firstName" name='firstName' required/>
            
            <label htmlFor="secondName">Фамилия</label>
            <input type="text" id="secondName" name='secondName' required />
            
            <label htmlFor="thirdName">Отчество</label>
            <input type="text" id="thirdName" name='thirdName' required />
            
            <label htmlFor="email">Почта</label>
            <input type="email" id="email" name='email' required />
            
            <label htmlFor="password">Пароль</label>
            <input type="password" id="password" name='password' required />

        </form>
    )
}