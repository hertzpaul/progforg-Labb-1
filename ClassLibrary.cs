namespace classes
{
    

class Entity{
    int x;
    int y;

    public  Entity(int x, int y){
        this.x = x;
        this.y = y;
    }
}

class Player : Creature{
    public Player (int x, int y, int speed, int strength, int health, int stamina) : base(x, y, speed, strength, health, stamina){

    }
}

class Creature : Entity {

    int strength; 
    int health;
    int stamina;
    int speed;

    public Creature(int x, int y, int speed, int strength, int health, int stamina) : base(x,y) {
        this.speed = speed;
        this.strength = strength;
        this.health = health;
        this.stamina = stamina;
    }

}

class Items : Entity{

    public Items(int x, int y) : base(x,y) {

    }
}
}