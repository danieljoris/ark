from beanie import PydanticObjectId, WriteRules
from dependency_injector.wiring import inject
from domain.entities.veterinary_clinic import VeterinaryClinic
from fastapi import APIRouter

router = APIRouter()


@router.post("")
async def create(veterinary_clinic: VeterinaryClinic):
    await veterinary_clinic.insert(link_rule=WriteRules.WRITE)
    return "Ok"


@router.get("/{id}")
async def get(id: PydanticObjectId):
    return await VeterinaryClinic.find_one(VeterinaryClinic.id == id, fetch_links=True)


@router.get("")
async def get_all() -> list[VeterinaryClinic]:
    return await VeterinaryClinic.find(fetch_links=True).to_list()
