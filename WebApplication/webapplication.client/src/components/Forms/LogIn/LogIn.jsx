import './LogIn.css'

export const LogIn = () =>{

    const handleSubmit = async (e) => {
        e.preventDefault();
        const formDictionary = { ...e.target };
        var data = new Map();
        for (var i = 0; i < 2; i++) {
            data.set(formDictionary[i].name, formDictionary[i].value)
        }
        const myJson = JSON.stringify(Object.fromEntries(data));
        const response = await fetch("/api/v1.0/user", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: myJson
        });
        debugger;
        if (response.status == 200) {
            const data = await response.json();
            debugger;
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
        <form id='loginForm' className="logInСontainer" onSubmit={handleSubmit}>
            <label for="email">Почта</label>
            <input type="email" id="email" name="email" />
            
            <label for="password">Пароль</label>
            <input type="password" id="password" name="password"/>
        </form>
    )
}