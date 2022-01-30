from sys import prefix

from app.routers.animals import router as animals_router
from app.routers.audit import router as audit_router
from app.routers.castrations import router as castrations_router
from fastapi import APIRouter

api_router = APIRouter()

api_router.include_router(animals_router, prefix="/animals", tags=["animals"])
api_router.include_router(audit_router, prefix="/audit", tags=["audit"])
api_router.include_router(
    castrations_router, prefix="/castrations", tags=["castrations"]
)
