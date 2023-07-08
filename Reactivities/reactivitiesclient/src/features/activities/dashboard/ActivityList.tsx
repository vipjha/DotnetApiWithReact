import React, { SyntheticEvent, useState } from 'react';
import { Button, Item, ItemGroup, Label, List, Segment } from 'semantic-ui-react';
import { Activity } from '../../../app/models/activity';
import { useStore } from '../../../app/stores/store';

interface Props {
    activities: Activity[];
    deleteActivity:(id:string)=>void;
    submitting: boolean;
}

export default function ActivityList({ activities,  deleteActivity, submitting}: Props) {
    
    const[target, setTraget] = useState('');

    function handleActvityDelete(e:SyntheticEvent<HTMLButtonElement>, id:string){
        setTraget(e.currentTarget.name);
        deleteActivity(id);
    }
    
    const {activityStore} = useStore();

    return (
        <Segment>
            <Item.Group divided>
                {activities.map((activity) => (
                    <Item key={activity.id}>
                      <Item.Content>
                        <Item.Header as='a'>{activity.title}</Item.Header>
                       <Item.Meta>{activity.date}</Item.Meta>
                        <Item.Description>
                            <div>{activity.description}</div>
                            <div>{activity.city}, {activity.venue}</div>
                        </Item.Description>
                        <Item.Extra>
                            <Button onClick={()=>activityStore.selectActivity(activity.id)} floated='right' content='View' color='blue'/>
                            <Button 
                            name={activity.id}
                            loading={submitting && target ===activity.id} 
                            onClick={(e)=>handleActvityDelete(e,activity.id)} 
                            floated='right' content='Delete' color='red'/>
                            <Label basic content={activity.category} />
                        </Item.Extra>
                      </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>
    )

}
