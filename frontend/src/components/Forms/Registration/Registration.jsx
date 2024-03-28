import './Registration.css'

export const Registration = () =>{

    const handleSubmit = (e) => {
        console.log(e.target);
        const formDictionary = { ...e.target };
        var data = new Map();
        for(var i = 0;i<5;i++){
            data.set(formDictionary[i].name, formDictionary[i].value)
        }
        const myJson = JSON.stringify(Object.fromEntries(data));
        fetch('api/v1.0/user')
            .then(response => response.text())
            .then(data => setImageData(data))
            .catch(error => console.log(error));
        console.log("asd");
    }

    return (
        <form id='registerForm' className="registerСontainer" onSubmit={handleSubmit}>

            <label htmlFor="firstName">Имя</label>
            <input type="text" id="firstName" name='firstName' />
            
            <label htmlFor="secondName">Фамилия</label>
            <input type="text" id="secondName" name='secondName' />
            
            <label htmlFor="thirdName">Отчество</label>
            <input type="text" id="thirdName" name='thirdName' />
            
            <label htmlFor="email">Почта</label>
            <input type="email" id="email" name='email' />
            
            <label htmlFor="password">Пароль</label>
            <input type="password" id="password" name='password' />

        </form>
    )
}