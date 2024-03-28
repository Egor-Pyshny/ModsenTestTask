import './Card.css'

export const Card = ({ Id, Name, Time, Country, City, OrganizerFirstName, OrganizerSecondName, Image, FreePlaces }) =>{
    return (
        <div className="cardContainer"> 
            <div className="nameContainer">
                {Name}
            </div>
            <div>
                <img src={`data:image/png;base64,${Image}`} alt="NotFound"/>
            </div>
            <div>
                <p>Place: { City + ", " + Country}</p>
                <p>Organizer: { OrganizerFirstName + " " +OrganizerSecondName }</p>
                <p>Time: {Time}</p>
                <p>FreePlaces: {FreePlaces}</p>
            </div>
        </div>
    )
}
