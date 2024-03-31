import { Registration } from '../Forms/Registration/Registration'
import { LogIn } from '../Forms/LogIn/LogIn'
import './StartPage.css'


export const StartPage = () =>{
    var form = <LogIn />;

    return (
        <div className='startPageMainDiv' id='startPageDiv'> 
            <div>
                <h1 className="startPageHeader">Test Task</h1>
                {form}
                <div className="buttonStartPageContainer">
                    <button className="enterButton" form="loginForm" type="submit">Войти</button>
                    <button className="registerButton" form="registerForm" type="submit">Зарегистрироваться</button>
                </div>
            </div>
        </div>
    )
}