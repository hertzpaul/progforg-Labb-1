
char[,] gameArray = new char[10,10];

class Entity{
    int x;
    int y;

    public  Entity(int x, int y){
        this.x = x;
        this.y = y;
    }
}

class player{

}

class creature : Entity {

    int strength;
    int health;
    int stamina;
    int speed;

    public creature(int x, int y, int speed, int strength, int health, int stamina) : base(x,y) {
        this.speed = speed;
        this.strength = strength;
        this.health = health;
        this.stamina = stamina;
    }

}

class items : Entity{

    public items(int x, int y) : base(x,y) {

    }
}