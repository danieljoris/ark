from enum import Enum
from typing import Dict, Optional
import pydantic

from domain.entities.core.entity import Entity
from beanie import PydanticObjectId

class AuditActionType(str, Enum):
    CREATE: str = "create"
    UPDATE: str = "update"
    DELETE: str = "delete"


class AuditRecord(Entity):
    entity_name: str = pydantic.Field(...)
    entity_id: PydanticObjectId
    action: AuditActionType = pydantic.Field(...)
    tenant_id: str = pydantic.Field(...)

    created_by_id: str = pydantic.Field(...)
    created_by_email: str = pydantic.Field(...)

    object: Optional[Dict] = pydantic.Field()
    new_object: Optional[Dict] = pydantic.Field()

    class Collection:
        name = "audit_records"
