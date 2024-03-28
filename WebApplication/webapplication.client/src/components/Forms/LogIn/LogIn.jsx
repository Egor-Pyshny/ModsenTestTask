import './LogIn.css'

export const LogIn = () =>{
    return (
        <form className="logInСontainer">
            <label for="email">Почта</label>
            <input type="email" id="email" required/>
            
            <label for="password">Пароль</label>
            <input type="password" id="password" required/>
        </form>
    )
}