import './MainPage.css'
import { Catalog } from '../Catalog/Catalog'
import { useEffect, useState } from 'react'

export const MainPage = () => {
    const [data, setData] = useState([])
    const getCatalog = async () => {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        setData(data);
    }
    useEffect(() => {
        getCatalog()
    }, [])

    return (
        <div className='mainMainPageDiv'>
            <div className='upBar'>
                <input className='showUserEventsBtn' type='Submit' value='Ваши события' />
            </div>
            <Catalog Cards={data} />
        </div>
    )
}
