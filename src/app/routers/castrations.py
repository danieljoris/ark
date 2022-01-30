from beanie import PydanticObjectId, WriteRules
from dependency_injector.wiring import inject
from domain.entities.castration import Castration
from fastapi import APIRouter

router = APIRouter()


@router.post("")
async def create(castration: Castration):
    await castration.insert(link_rule=WriteRules.WRITE)
    return "Ok"


@router.get("/{id}")
async def get(id: PydanticObjectId):
    return await Castration.find_one(Castration.id == id, fetch_links=True)


@router.get("")
async def get_all() -> list[Castration]:
    return await Castration.find(fetch_links=True).to_list()
