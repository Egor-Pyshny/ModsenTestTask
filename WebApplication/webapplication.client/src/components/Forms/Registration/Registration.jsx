import './Registration.css'

export const Registration = () =>{

    const error = document.getElementById('errorMessage');
    if (error) {
        error.remove();
    }

    const handleSubmit = async (e) => {
        e.preventDefault();
        const formDictionary = { ...e.target };
        var data = new Map();
        for (var i = 0; i < 5; i++) {
            data.set(formDictionary[i].name, formDictionary[i].value)
        }
        const myJson = JSON.stringify(Object.fromEntries(data));
        const response = await fetch("/api/v1.0/user", {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: myJson,
        });
        if (response.status == 201) {
            const data = await response.json();
            localStorage.setItem('userId', data);
        } else {
            const errorMessage = document.getElementById('errorMessage');
            if (errorMessage == null) {
                const paragraph = document.createElement('p');
                paragraph.textContent = 'Ошибка при выполнении запроса';
                paragraph.style.color = 'red';
                paragraph.id = 'errorMessage'
                paragraph.style.fontSize = '30px';
                const container = document.getElementById('root');
                container.appendChild(paragraph);
            }
        }
    }

    return (

        <div className='startPageMainDiv' id='startPageDiv'>
            <div>
                <h1 className="startPageHeader">Test Task</h1>
                <form id='registerForm' className="registerСontainer"
                    onSubmit={handleSubmit}>

                    <label htmlFor="firstName">FirstName</label>
                    <input type="text" id="firstName" name='firstName' required/>
            
                    <label htmlFor="secondName">SecondName</label>
                    <input type="text" id="secondName" name='secondName' required />
            
                    <label htmlFor="thirdName">ThirdName</label>
                    <input type="text" id="thirdName" name='thirdName' required />
            
                    <label htmlFor="email">Email</label>
                    <input type="email" id="email" name='email' required />
            
                    <label htmlFor="password">Password</label>
                    <input type="password" id="password" name='password' required />

                </form>
                <div className="buttonStartPageContainer">
                    <button className="enterButton" type="button">Войти</button>
                    <button className="registerButton" form="registerForm" type="submit">Зарегистрироваться</button>
                </div>
            </div>
        </div>
    )
}