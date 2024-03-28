import './Catalog.css'
//import { Card } from '../Card'


export const Catalog = (Cards) =>{
    return (
        <div className='cardsContainer'>
            {Cards.map(c => <Card 
                Id = {c.id}
                Name = {c.name}
                Time = {c.time}
                Country = {c.country}
                City = {c.city}
                OrganizerFirstName = {c.OrganizerFirstName}
                OrganizerSecondName = {c.OrganizerSecondName} 
                Image = {c.image}
                FreePlaces = {c.freePlaces}
            />)}
        </div>
    )
}