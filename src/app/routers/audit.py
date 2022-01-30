from fastapi import APIRouter, Depends
from dependency_injector.wiring import inject, Provide

from fastapi_pagination import Page
from app.dependencies import Container
from motor.motor_asyncio import AsyncIOMotorClient
from domain.entities.audit import AuditRecord
from fastapi_contrib.pagination import Pagination
from fastapi_contrib.serializers.common import ModelSerializer

router = APIRouter()

@router.post("")
@inject
async def create(audit: AuditRecord):
    await audit.insert()

    return "Ok"


class SomeSerializer(ModelSerializer):
    class Meta:
        model = AuditRecord

@router.get("", response_model=Page[AuditRecord])
@inject
async def get(pagination: Pagination = Depends(),client: AsyncIOMotorClient = Depends(Provide[Container.motor_client])):
    collection = client.db_name.audit_records.find()
    result = paginate(collection)

    return result