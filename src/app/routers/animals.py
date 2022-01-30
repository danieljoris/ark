from beanie import PydanticObjectId, WriteRules
from dependency_injector.wiring import inject
from domain.entities.animal import Animal
from fastapi import APIRouter

router = APIRouter()


@router.post("")
async def create(animal: Animal):
    await animal.insert(link_rule=WriteRules.WRITE)
    return "Ok"


@router.get("/{id}")
async def get(id: PydanticObjectId):
    return await Animal.find_one(Animal.id == id, fetch_links=True)


@router.get("")
async def get_all() -> list[Animal]:
    return await Animal.find(fetch_links=True).to_list()
