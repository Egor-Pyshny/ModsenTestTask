import './DetailedCard.css'

export const DetailedCard = ({ 
    Id, 
    Name, 
    Time, 
    Country, 
    City, 
    Street,
    OrganizerFirstName, 
    OrganizerSecondName,
    FreePlaces,
    SpickerFirstName,
    SpickerSecondName 
    }) =>{
    return (
        <div> 
            <div className="nameContainer">
                {Name}
            </div>
            <div>
                <p>Place: { City + ", " + Country}</p>
                <p>Organizer: { OrganizerFirstName + " " +OrganizerSecondName + " " + Street }</p>
                <p>Spicker: { SpickerFirstName + " " +SpickerSecondName }</p>
                <p>Time: {Time}</p>
                <p>FreePlaces: {FreePlaces}</p>
            </div>
        </div>
    )
}
