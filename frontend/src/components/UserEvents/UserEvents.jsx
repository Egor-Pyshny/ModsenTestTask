import './UserEvents.css'
import { Catalog } from '../Catalog/Catalog'

export const UserEvents = () =>{
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
        <div className='mainUserEventsPageDiv'>
            <div className='upBar'>
                <input className='showUserEventsBtn' type='Submit' value='Все события'/>
            </div>
            <Catalog Cards={data}/>
        </div>
    )
}