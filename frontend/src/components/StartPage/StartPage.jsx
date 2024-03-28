import { Registration } from '../Forms/Registration/Registration'
import './StartPage.css'


export const StartPage = () =>{
    return (
        <div className='startPageMainDiv'> 
            <div>
                <h1 className="startPageHeader">Test Task</h1>
                <Registration/>
                <div className="buttonStartPageContainer">
                    <button className="enterButton" type="button">Войти</button>
                    <button className="registerButton" form="registerForm" type="submit">Зарегистрироваться</button>
                </div>
            </div>
        </div>
    )
}